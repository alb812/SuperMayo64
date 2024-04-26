using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Usage: Attach this to Mario Character controller. This manages all Mario's actions.
// The main actions Mario performs are all in different functions. ex: UpdateJump manages jump 
// All these functions and others are called from Update() each frame. Remaining Movement code via physics engine in FixedUpdate() near the bottom.  

public class Mario_Controller : MonoBehaviour
{
    
    public GameObject CrouchIndicator; // Temp object to indicate crouch; - replace with Animation

    public float MoveSpeed;
    public float MaxSpeed;
    public float InAirMoveSpeed;
    public float JumpForce;

    public float InverseMagnitude; // Simulated drag
    public float MagAirMultiplier = 0.5f;

    public float SingleJumpForce = 100;
    public float DoubleJumpForce = 150;
    public float TripleJumpForce = 200;
    public float ComboJumpGracePeriod = 0.5f; //how long player can be grounded before currentJump resets
    public float minSpeedForTriple = 7f;

    public float MaxClimbAngle = 60;

    public float LongjumpThreshhold = 2;

    public float PipeDescentSpeed = 2.5f;

    private Rigidbody rb;
    private Vector3 inputVector;
    private Vector3 rev_inputVector; // Uses InverseMagnitude to create force simulating drag. 
    private Vector3 jumpVector;

    [HideInInspector]
    public bool isControllable = true;
    [HideInInspector]
    public bool isGrounded;
    private bool isJumping1 = false;
    private bool isCrouching = false;

    private float startingMovespeed;

    private float moveVelocity_X;
    private float moveVelocity_Z;
    private float startingAirSpeed;

    private float timeSinceGrounded; // timer variable for double/triple jump
    private int currentJump = 1; //tracks which jump will be next

    private bool OnSlope = false;

    [HideInInspector]
    public bool noBetterJump;

    public Animator anim;

    private Ray rayForDebug;
    
    //For Audio GetKey stuff (Crouch)
    private bool AudioIsPlaying;
    public AudioSource MarioCrouchAudio;
    public AudioSource LongJumpAudio;
    public AudioSource BackflipAudio;

    private void Start()
    {
        CrouchIndicator.SetActive(false);

        rb = this.GetComponent<Rigidbody>();
        startingMovespeed = MoveSpeed;
        startingAirSpeed = InAirMoveSpeed;

        moveVelocity_X = 0;
        moveVelocity_Z = 0;
    }


    // Update calles each of the following funtions each frame. I break the functions up just to keep Update() from being over cluttered. 
    private void Update()
    {
        if (!isControllable) // This is the condition for winning the game, in which player control is reliquished and Mario descends down the pipe to victory.
        {
            rb.velocity = Vector3.zero;
            this.transform.position += (Vector3.down*PipeDescentSpeed) * Time.deltaTime;
            anim.SetBool("hasWon", true);
        }
        else
        {
            // The Main Game Control Loop. These are all of Mario's actions dictated by player control, each in their own function. 
            UpdateRaycast();
            UpdateMovement();
            StopControl();
            CheckComboJump();
            UpdateJump();
            FallDampen();
            UpdateCrouch();
        }
        //Debug.Log(MoveSpeed);
        //Debug.Log(OnSlope);
    }

    // Crouch code - press shift to crouch
    // TODO: add crouch+Backflip and running crouch+Longjump
    private void UpdateCrouch()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            isCrouching = true;
            //CrouchIndicator.SetActive(true);
            anim.SetBool("isCrouching", true);

            // TODO: Crouch animation
            // TODO: ? Crouch sound effect ?
            //AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioCrouch);
            /*if (MarioCrouchAudio.isPlaying == false)
            {
                MarioCrouchAudio.Play();
            }
            else
            {
                MarioCrouchAudio.Stop();
            }*/
        }
        else
        {
            isCrouching = false;
            //CrouchIndicator.SetActive(false);
            anim.SetBool("isCrouching", false);
            // TODO: Standing up Animation
            //AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioGetUp);
        }

        // If you jump while crouching (and on the ground, of course)
        if (Input.GetKeyDown(KeyCode.Space) && isCrouching && isGrounded)
        {
            // If you are moving, long jump. ELSE, Backflip
            if (Mathf.Abs(rb.velocity.x) > LongjumpThreshhold || Mathf.Abs(rb.velocity.z) > LongjumpThreshhold)
            {
                //Debug.Log("LONGJUMP - MOVING" + rb.velocity.x + "    " + rb.velocity.z);
                Longjump();
            }
            else
            {
                //Debug.Log("BACKFLIP - still" + rb.velocity.x + "    " + rb.velocity.z);
                Backflip();
            }
        }
    }

    // These two methods below are called inside UpdateCrouch() 
    // Backflip is called when Mario is stationary - causes him to do his backflip.
    private void Backflip()
    {
        noBetterJump = true;

        Vector3 BackflipTrajectory = this.transform.forward;
        BackflipTrajectory += new Vector3(0,10,0);

        InAirMoveSpeed = 12;
        rb.AddForce(new Vector3(0, 16, 0), ForceMode.Impulse);
        
        //audio
        //AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioJumpBackflip);
        if (BackflipAudio.isPlaying == false)
        {
            BackflipAudio.Play();
        }
        else
        {
            BackflipAudio.Stop();
        }


        //rb.AddForce(BackflipTrajectory, ForceMode.Impulse);
        //rb.AddForce(transform.forward * 20, ForceMode.Impulse);
        //rb.AddForce(new Vector3(10,10,10), ForceMode.Impulse);
    }
    // Longjump is called when Mario is moving - causes him to do his long jump. 
    private void Longjump()
    {
        anim.SetBool("hasLongJumped", true);

        noBetterJump = true;

        InAirMoveSpeed = 220;
        rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);

        
        //audio
        //AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioJumpLong);
        if (LongJumpAudio.isPlaying == false)
        {
           LongJumpAudio.Play();
        }
        else
        {
           LongJumpAudio.Stop();
        }
        
    }

    // Projects a raycast underneath Mario to detect if you are on/near the ground
    // This also manages the horizontal raycast to detect slopes.
    private void UpdateRaycast()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        
        float maxRayDist = 1.2f;

        Debug.DrawRay(ray.origin, ray.direction * (maxRayDist+0.35f), Color.yellow);

        rayForDebug = ray;



        //if (Physics.Raycast(ray, maxRayDist))
        if (Physics.SphereCast(ray, 0.35f, maxRayDist))
        {
            //Debug.Log("@@@ On ground ray");
            isGrounded = true;
            noBetterJump = false;

            if (rb.velocity.y < 0.1)
            {
                anim.SetBool("isGrounded", true);
                anim.SetBool("hasJumped", false);
                anim.SetBool("hasLongJumped", false);
            }
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }

        Vector3 tempHorizontal = new Vector3(this.transform.position.x, this.transform.position.y - 0.9f, this.transform.position.z);
        Ray HorizontalRay = new Ray(tempHorizontal, this.transform.forward);
        float maxHorizontalRayDist = 1f;
        RaycastHit HorizontalHit;

        Debug.DrawRay(HorizontalRay.origin, HorizontalRay.direction * maxHorizontalRayDist, Color.blue);
        if (Physics.Raycast(HorizontalRay, out HorizontalHit, maxHorizontalRayDist))
        {
            OnSlope = true;

            float slopeAngle = Vector3.Angle(HorizontalHit.normal, Vector3.up);
            Debug.Log(slopeAngle);//"Hit Horizontal");

            if (slopeAngle <= MaxClimbAngle)
            {
                Vector3 velocity = rb.velocity;
                //ClimbSlope(ref velocity, slopeAngle);
                tempSlope(slopeAngle);
            }
        }
        else
        {
            OnSlope = false;

            //temp
            MoveSpeed = startingMovespeed;
        }
    }

    // Starting movespeed = 40
    private void tempSlope(float angle)
    {
        Debug.Log(angle);
        if (OnSlope == true)
        {
            if (angle > 30)
                MoveSpeed = 130;
            else if (angle > 20)
                MoveSpeed = 100;
            else if (angle > 15)
                MoveSpeed = 80;
            else if (angle > 10)
                MoveSpeed = 70;
            else if (angle > 5)
                MoveSpeed = 60;
        }

    }

    private void ClimbSlope(ref Vector3 velocity, float slopeAngle)
    {
        Debug.Log("Climbing Slope");
        float MoveDistance = Mathf.Abs(velocity.x);
        velocity.y = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * MoveDistance;
        velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * MoveDistance;

        //added
        rb.velocity = new Vector3(velocity.x, velocity.y, rb.velocity.z);

    }

    // Adds adverse force when landing from a jump to avoid collision/getting stuck in the ground. 
    private void FallDampen()
    {
        if (isGrounded && rb.velocity.y < -10)
        {
            rb.velocity = new Vector3(rb.velocity.x, -4, rb.velocity.z);
            Debug.Log(" -- Fall Dampened");
        }
    }

    // Main movement code
    private void UpdateMovement()
    {

        moveVelocity_X = Input.GetAxis("Horizontal");
        moveVelocity_Z = Input.GetAxis("Vertical");


        inputVector = new Vector3(moveVelocity_X, 0f, moveVelocity_Z).normalized;
        inputVector = Camera.main.transform.TransformDirection(inputVector);
        inputVector.y = 0;

        Vector3 InverseDirection = (this.rb.velocity.normalized * -1);
        float InverseMagnitude;

        // When on the ground
        if (isGrounded)
        {
            inputVector *= MoveSpeed;
            InverseMagnitude = this.InverseMagnitude;
            // TODO: Normal walk animation
            // TODO: Normal walk sound effect
            //
        }
        else // When in the air - move slower/less x/z control
        {
            inputVector *= InAirMoveSpeed;
            InverseMagnitude = this.InverseMagnitude * MagAirMultiplier;
            // TODO: Falling animation
            // TODO: ? Falling sound effect ?
        }

        if (inputVector != Vector3.zero && isGrounded)
        {
            this.transform.rotation = Quaternion.LookRotation(inputVector);
        }

        rev_inputVector = InverseDirection * InverseMagnitude;


        // Manages animations and sound effects for running/footsteps
        if (Mathf.Abs(rb.velocity.x) > 0.5 || Mathf.Abs(rb.velocity.z) > 0.5)
        {
            anim.SetBool("isRunning", true);

            if (isGrounded)
            {
                
                //audio
                //AudioManager.Instance.PlayRandomFromArray(AudioManager.Instance.FootstepSounds);
                //AudioManager.Instance.PlayMarioFootsteps(AudioManager.Instance.FootstepSounds);
            }
        }
        else
            anim.SetBool("isRunning", false);
    }

    // Jumping - single, double and triple jump
    private void UpdateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            InAirMoveSpeed = startingAirSpeed;

            //Jump Animation
            anim.SetBool("hasJumped", true);


            //check horizontal velocity to see if player can do triple jump
            if (currentJump == 3)
            {
                Vector3 horizontalVelocity = rb.velocity;
                horizontalVelocity.y = 0;
                float velocityMag = horizontalVelocity.magnitude;

                if (velocityMag < minSpeedForTriple)
                {
                    currentJump = 1;
                }
            }

            //adjust JumpForce based on currentJump
            switch (currentJump)
            {
                case 1:
                    JumpForce = SingleJumpForce;

                    // TODO: Single jump animation
                    // TODO: Single jump sound effect
                    AudioManager.Instance.PlayRandomFromArray(AudioManager.Instance.MarioJumpx1);
                    break;
                case 2:
                    JumpForce = DoubleJumpForce;
                    // TODO: Double jump animation
                    // TODO: Double jump sound effect
                    AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioJumpx2);
                    break;
                case 3:
                    JumpForce = TripleJumpForce;
                    // TODO: Triple jump animation
                    // TODO: Triple jump sound effect
                    AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioJumpx3);
                    break;
                default:
                    Debug.Log("Jump out of bounds");
                    break;

            }
            anim.SetInteger("jumpCounter", currentJump);


            jumpVector = Vector3.up * JumpForce;
            rb.AddForce(jumpVector, ForceMode.Impulse);
            timeSinceGrounded = 0;

            //When you jump, change to next jump. Reset after three
            currentJump++;
            //Debug.Log(currentJump);
            if (currentJump > 3)
            {
                currentJump = 1;
                // Debug.Log(currentJump);
            }
        }
    }

    // Checks how long the player has been grounded for. After the grace period, the player can no longer combo jump and is reset to the first jump
    private void CheckComboJump()
    {
        if (isGrounded)
        {
            timeSinceGrounded += Time.deltaTime;
        }
        else
        {
            timeSinceGrounded = 0;
        }

        if (timeSinceGrounded > ComboJumpGracePeriod)
        {
            currentJump = 1;
            //Debug.Log(currentJump);
        }
    }

    private void StopControl()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }


    // Calls player movement via rb physics
    // Adds force for normal movement, and an inverse force to similate drag/friction and jump gravity.  
    private void FixedUpdate()
    {
        
        Vector3 temp = inputVector + rev_inputVector;

        //rb.AddForce(temp, ForceMode.Force);

        if (!isCrouching)
        {
            rb.AddForce(temp, ForceMode.Force);
        }

        float tempX = rb.velocity.x;
        float tempZ = rb.velocity.z;

        Vector3 tempV3 = new Vector3(tempX, 0, tempZ);

        if (tempV3.magnitude > MaxSpeed)
        {
            Vector3 tempVNorm = tempV3.normalized * MaxSpeed;
            rb.velocity = new Vector3(tempVNorm.x, rb.velocity.y, tempVNorm.z);
        }

        //Debug.Log(rb.velocity);

    }

    /*private void OnCollisionEnter(Collision coll)
    {

    }

    private void OnCollisionExit(Collision coll)
    {

    }*/

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(this.transform.position , 5);
    }
}
