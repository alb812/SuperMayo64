using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on the moving horizontal diamond platforms 
//INTENT: Moves the horizontal platforms in a square formation
public class HorizontalMovingPlatform : MonoBehaviour {

	public Transform[] target;
	public float speed;
	
	private int current;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//if the transform position is not the current target position
		if (transform.position != target[current].position)
		{
			//move the gameobject to the target position
			transform.position = Vector3.MoveTowards(transform.position, target[current].transform.position,
				speed * Time.deltaTime);
			//changes the current position each time the platform moves so it constantly moves
		} else current = (current + 1) % target.Length;
 
		
		//draws line to visualize movement
		Debug.DrawLine( transform.position, target[current].position, Color.yellow);
		
	}
}
