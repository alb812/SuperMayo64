using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingAnchor : MonoBehaviour
{

	public float moveSpeed;
	// Update is called once per frame
	void Update () {
		transform.Rotate(moveSpeed, 0, 0);
	}
}
