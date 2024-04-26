using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class marioHealthDeath : MonoBehaviour
{
	//usage: put this on a capsule with a rigidbody
	//intent: moves Trash Mario and controls his death function
	public float moveSpeed = 10f;

	// Connor's add-on
	// Animator that controls the movement of the powercircle
	public Animator powercircleAnim;
	public int timeSinceDmg;
	private int temp;
	
	//this variable remembers input and passes it to physics
	private Vector3 inputVector;
	public int startHealth = 8;
	public static int health;
	public float LookSpeed = 100f;
	public static marioHealthDeath itsame;
	private Vector3 startpos;

	//Ariana Addition
	public float lifetime = 6f;
	public bool isDeadDelay;

	//public Animator powerAnimator;
	
	// Use this for initialization
	void Start()
	{
		// Connor cont'd
		temp = timeSinceDmg;
		health = startHealth;
		
		itsame = this;
		startpos = transform.position;
		isDeadDelay = false;

	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(temp);
		
		if (temp < timeSinceDmg)
		{
			temp++;
		}
		else if(temp >= timeSinceDmg)
		{
			powercircleAnim.SetBool("isVisible", false);
		}
		
		if (Input.GetKeyDown(KeyCode.K))
		{
			//takedamage is WIP script for when health comes into play
			//Death() happens when you die! 
			TakeDamage();
		}
		
		//Ariana Coroutine
		if (isDeadDelay == true)
		{
			StartCoroutine(MarioDeathDelay());
		}


		/*if (Input.GetMouseButtonDown(0)) //0 = left, 1 = right, 2 = middleclick
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		//----------------------------- 
		//WASD MOVEMENT: TEMPORARY FOR TESTING. just comment all this out when you implement it in the level
		float horizontal = Input.GetAxis("Horizontal"); // a d
		float vertical = Input.GetAxis("Vertical"); // w s 
		//apply keyboard input to position

		//collecting data. remember to use += so it means 'also equals' i guess??
		inputVector = transform.forward * vertical;
		inputVector += transform.right * horizontal;
		*/

	}
	//physics code for temp movement code
	/*void FixedUpdate()
	{
		//override object's velocity with desired inputVector direction
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * 0.5f;
	}*/



//literally when you take damage
	public void TakeDamage()
	{
		if (health > 0)
		{
			// Connor cont'd
			temp = 0;
			powercircleAnim.SetBool("isVisible", true);
			health--;
			//Audio
			AudioManager.Instance.PlayRandomFromArray(AudioManager.Instance.MarioStagger);
		}

		if (health <= 3)
		{
			//Do some panting 
		}
		
		

		if (health <= 0)
		{
			Death();
			//regular death audio
			AudioManager.Instance.PlayAudioClip(AudioManager.Instance.MarioLowHealthDeath);	
		}
	}


	//this happens when you press K to take damage and you reach 0
	public void Death()
	{
		livesUI.me.LostALife();
		health = 8;
		transform.position = startpos;
		isDeadDelay = false;
		
	}

	//specific to fall death
	public void MarioFallDeath()
	{
		livesUI.me.LostALife();
		health = 8;

		//Ariana - moving this so there's a delay so we can hear Mario scream a bit
		//transform.position = startpos;
		isDeadDelay = true;
	}

	
	IEnumerator MarioDeathDelay()
	{
		while (lifetime > 0)
		{
			yield return new WaitForSeconds(1);

			lifetime--;
			break;
		}

		lifetime = 6f;
		isDeadDelay = false;
		transform.position = startpos;
		StopCoroutine(MarioDeathDelay());
		
	}
}
