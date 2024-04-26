using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {

	//assign in inspector
	public float moveSpeed = 3;
	public Transform[] PatrolPoints; //create a number of empty game objects, using their transform as the locations the object will patrol between
	
	public int patrolIndex = 0;
	private Rigidbody rb;
	
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		Patrol();
	}
	
	//walk between patrol points when not chasing player
	//always starts with [0], walks in the order of the array, and loops
	void Patrol()
	{
		Vector3 directionToNextPoint = (PatrolPoints[patrolIndex].position - transform.position).normalized;
		transform.LookAt(PatrolPoints[patrolIndex]);
		rb.velocity = directionToNextPoint * moveSpeed;

		if (Vector3.Distance(transform.position, PatrolPoints[patrolIndex].position) < 0.5)
		{
			patrolIndex++;
			if (patrolIndex >= PatrolPoints.Length)
			{
				patrolIndex = 0;
			}
		}
	}
}
