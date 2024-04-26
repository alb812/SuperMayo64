using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayFootstepsScript : MonoBehaviour
{

	public Mario_Controller marioController;
	
	// Use this for initialization
	void Start ()
	{
		marioController = transform.parent.GetComponent<Mario_Controller>();
	}
	
	public void PlayMarioFootsteps()
	{
		if (marioController.isGrounded == true)
		{
			AudioManager.Instance.PlayFootstepSound();
		}
	}
}
