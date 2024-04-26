using UnityEngine;
using System.Collections;

// Modified third-person controller. Use this to create an FPS style view for the camera,
// attach to any capsule primitive in order for the script to work
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CapsuleController : MonoBehaviour
{
	private Rigidbody rigidbody;

	[System.Serializable]
	public class ControllerSettings
	{
		public float speed = 10.0f;
		public float gravity = 10.0f;
		public float maxVelocityChange = 10.0f;
		public bool canJump = true;
		public float jumpHeight = 2.0f;
	}
	[SerializeField]
	public ControllerSettings controller;
	
	private bool grounded = false;
	
	void Awake ()
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.useGravity = false;
	}
	
	void FixedUpdate () {
		if (grounded) {
			
			// Calculates how fast the player should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= controller.speed;
 
			// When the player is moving, applies force in an attempt to reach the target velocity
			Vector3 velocity = rigidbody.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -controller.maxVelocityChange, controller.maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -controller.maxVelocityChange, controller.maxVelocityChange);
			velocityChange.y = 0;
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
			if (controller.canJump && Input.GetButton("Jump")) {
				rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}
		
		// Gravity is applied manually for more tuning control, editable
		rigidbody.AddForce(new Vector3 (0, -controller.gravity * rigidbody.mass, 0));
		grounded = false;
	}

	void OnCollisionStay () {
		grounded = true;    
	}
 
	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * controller.jumpHeight * controller.gravity);
	}
}