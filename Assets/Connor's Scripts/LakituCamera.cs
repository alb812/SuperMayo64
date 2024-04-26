using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Put this script on an empty parent to the main camera. Used to control the camera
// from the pivot in the center of Mario, to recreate the Lakitu effect in the original game
public class LakituCamera : MonoBehaviour
{
	public Transform mario;
	
	public GameObject mainCamera;

	// The pivot points the camera is positioned at, editable in the inspector
	public Transform near, neutral, far;

	// Time it takes the main camera to rotate around Mario
	public float cameraRotTime = 1.0f;
	
	// Time it takes the main camera to lerp between the pivot index
	public float pivotLerpTime = 1.0f;
	
	// Amount of smoothing applied to the camera when it follows Mario
	public float cameraSmooth = 1.0f;
	
	// Smoothing variable
	private float smooth = 5.0f;

	// Index of what pivot point the camera is currently positioned at
	// i.e. 0 = near, 1 = neutral, 2 = far
	private int camIndex = 1;

	// Target rotation
	private Quaternion destinationRotation;

	// Target position
	private Transform destinationPosition;

	public void Start()
	{
        // Sets the default rotation directly behind Mario, facing the level.
        destinationRotation = Quaternion.Euler(0, 180, 0);

		// Sets default position as neutral, like in the game
		destinationPosition = neutral;
	}
	
	// Update is called once per frame
	void Update () {

		// Checks to see if mario returns true (which it A L W A Y S should)
		// before starting
		if (mario)
		{
			// Camera is constantly following Mario, preferred over smoother versions to
			// more closely emulate 64

			// Left/right arrow keys rotate the camera on the y-axis, in 45 degree increments each key press
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				RotateCamera(45.0f);
				//Audio - Ariana
				AudioManager.Instance.PlayAudioClip(AudioManager.Instance.CameraLeft);
			}

			// cont'd
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{

				RotateCamera(-45.0f);
				//Audio - Ariana
				AudioManager.Instance.PlayAudioClip(AudioManager.Instance.CameraRight);
			}

			// Up/down arrow keys increase/decrease camIndex,
			// which controls the location of the camera relative to Mario
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (camIndex == 0)
				{
					camIndex++;
					//Audio - Ariana
					AudioManager.Instance.PlayAudioClip(AudioManager.Instance.CameraOut);
				}
				else if (camIndex == 1)
				{
					camIndex++;
					//Audio - Ariana
					AudioManager.Instance.PlayAudioClip(AudioManager.Instance.CameraOut);
				}
				else if (camIndex == 2)
				{
					return;
				}

				PivotIndex(camIndex);
			}

			// cont'd
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (camIndex == 0)
				{
					return;
				}
				else if (camIndex == 1)
				{
					camIndex--;
					//Audio - Ariana
					AudioManager.Instance.PlayAudioClip(AudioManager.Instance.CameraIn);
				}
				else if (camIndex == 2)
				{
					camIndex--;
					//Audio - Ariana
					AudioManager.Instance.PlayAudioClip(AudioManager.Instance.CameraIn);
				}

				PivotIndex(camIndex);
			}

			//Debug.Log(camIndex);

			// Rotates the camera in update, to ensure calculations are constantly done in update
			transform.rotation = Quaternion.Slerp(transform.rotation, destinationRotation, cameraRotTime);

			// Moves the mainCamera, not the cameraRig to the specified pivot point.
			// When editing, make sure the mainCamera is being moved
			mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position,
				new Vector3(destinationPosition.position.x, destinationPosition.position.y,
					destinationPosition.position.z), pivotLerpTime);
		}
	}

	// Fixed update is to prevent stuttering and tearing on the camera, which would happen if the code
	// was left in update
	void FixedUpdate()
	{
		// Finds Mario in the scene by calling FindMario
		if (!mario)
		{
			FindMario();
		}
		else
		{
			// If Mario is found, then store Mario's position as a Vector3 so that the camera can move
			// based on mario's position
			Vector3 targetPosition = mario.position;
			
			// Follows Mario
			FollowMario(targetPosition);
		}
	}

	// Pass a rotation float when calling RotateCamera, that's the increment in which the camera
	// will be rotated
	void RotateCamera(float rotation)
	{
		// Creates the new rotation with the value passed to the function in update (+/-45.0f)
		Quaternion newRotation = Quaternion.AngleAxis(rotation, Vector3.up);

		// Rotates the camera rig to the new rotation
		destinationRotation *= newRotation;
	}

	// Checks against the pivot to decide where the mainCamera should be going
		void PivotIndex(int pivot)
	{
		if (pivot == 0)
		{
			destinationPosition = near;
		}
		if (pivot == 1)
		{
			destinationPosition = neutral;
		}
		if (pivot == 2)
		{
			destinationPosition = far;
		}
	}
	
	// Following the target with Time.deltaTime smoothly
	void FollowMario(Vector3 targetPosition)
	{
		if (!Application.isPlaying)
		{
			// Sets the transform.position as the targetPosition
			transform.position = targetPosition;
		}
		else
		{
			// Lerps the camera to follow Mario, creates that signature 'lagging-behind' effect, like Lakitu in
			// the original
			Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSmooth);
			transform.position = newPos;
		}
	}
	
	// Finds the player and sets it as target to follow
	void FindMario()
	{
		// GameObject tagged "Player" will be Mario, set it as such in the inspector
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		// If "Player" is true (which it should A L W A Y S be)
		if (player)
		{
			// Store transform and pass it to the mario variable
			Transform playerTransform = player.transform;
			mario = playerTransform;
		}
	}
}
