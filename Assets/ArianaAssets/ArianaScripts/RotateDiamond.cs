using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//USAGE: Put this on diamond gameobject holding the WHEEL 
//intent: spins the back platform holding the "wheel"
public class RotateDiamond : MonoBehaviour
{

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f , 0f, speed);
	}
}
