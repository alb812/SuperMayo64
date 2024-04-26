using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INTENT: Makes platforms move along with diamond
//USAGE: Put this on the gameobject that holds the moving wheel platforms
public class RotatePlatforms : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(speed , 0f, 0f);
	}
}
