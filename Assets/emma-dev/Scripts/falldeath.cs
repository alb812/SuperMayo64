using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class falldeath : MonoBehaviour {
	//usage: put this on a big cube below the world with a trigger on it
	//intent: kill mario when he falls onto it

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//calling function and then destroying self
		marioHealthDeath.itsame.MarioFallDeath();
			//audio
			AudioManager.Instance.PlayMarioFallDeathSound();

		}
		
		
	}
}
