using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put on mushroom gameObject that instantiates from block breaking
public class mushroomScript : MonoBehaviour {

//Gives player a life when collected
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			livesUI.me.GainALife();
			AudioManager.Instance.PlayOneUpGrabbedSound();
			Destroy(this.gameObject);
		}
	}
}
