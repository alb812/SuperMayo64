using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingPlatform : MonoBehaviour
{

	public Transform parentAnchor;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		transform.rotation = Quaternion.Euler(new Vector3(0,90,0));

	}
}
