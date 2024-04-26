using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: Put this on the yellow block 
//intent: makes block move back and forth

public class YellowBlockScript : MonoBehaviour
{

	public float amplitude = 0.5f;
	private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
	//initializes the starting position on the block
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //makes the block bounce on a vertical axis
		//literally just Robert's script
		Vector3 bounceOffset = Vector3.forward * Mathf.Sin(Time.time) * amplitude;
		transform.position = startPos + bounceOffset;
	}
}
