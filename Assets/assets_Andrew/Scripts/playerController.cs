using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	private float horizontal;
	private float vertical;
	
	public float moveSpeed;

	
	void Update ()
	{
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		transform.Translate(new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime);
	}
}
