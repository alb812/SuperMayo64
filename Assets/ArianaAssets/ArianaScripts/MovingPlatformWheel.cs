using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on the platforms of the wheel 
//INTENT: Keeps children of rotating wheel stationary
public class MovingPlatformWheel : MonoBehaviour
{

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		//VERY IMPORTANT LINE, VALUE CHANGES BASED ON WHEELS DIRECTION 
		//rotates the platforms on the wheel
		//Change the y value if you rotate the cube (x, y, z);
		transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

	}
}
