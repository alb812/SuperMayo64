using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to any gameobject that can rotate, has the object look at the target
// specified in the inspector, useful for testing

public class Looking : MonoBehaviour
{

	public Transform target;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
	}
}