using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starscript : MonoBehaviour {
	//usage: put this on a star object w/ a trigger
	//intent: collect a star when mario walks into it

	private Mario_Controller player;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<Mario_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//calling function and then destroying self
			starsUI.me.FoundAStar();
			AudioManager.Instance.PlayMarioGrabStarSound();

			StartCoroutine(CollectStar());
			//Destroy(this.gameObject);
		}
	}

	IEnumerator CollectStar()
	{
		this.GetComponent<MeshRenderer>().enabled = false;
		
		player.anim.SetBool("isDancing", true);
		player.isControllable = false;
		
		yield return new WaitForSeconds(6.5f);
		
		player.anim.SetBool("isDancing", false);
		player.isControllable = true;
		
		Destroy(this.gameObject);
	}
	
}
