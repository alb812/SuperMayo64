using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: Put this on the MARIO Character
//Intent: Allows player to stand on moving rigidbody platforms

public class HoldCharacter : MonoBehaviour
{


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	void OnTriggerEnter(Collider other)
	{
		// if Mario hits the MovingPlatform trigger, he becomes a child of it
		if (other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = other.transform;
		}
	}

	void OnTriggerExit(Collider other)
		{
			//when Mario leaves the trigger, he is no longer a child of it
			if (other.gameObject.tag == "MovingPlatform")
			{
				transform.parent = null;
			}
		}
	}

