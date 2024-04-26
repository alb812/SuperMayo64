using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this script on goombas (enemies) in the level
public class enemyBehaviour : MonoBehaviour
{
    //assign in inspector
	public Transform player;
	public float moveSpeed = 3;
	public float maxMoveSpeed;
	public float chaseSpeed = 4;
	public float maxChaseSpeed;
	public float rotationSpeed = 3;
	public float detectionDist = 5;
	public float maxChaseDist = 7;
	public Transform[] PatrolPoints; //create a number of empty game objects, using their transform as the locations the object will patrol between

	private Rigidbody rb;
	private int patrolIndex = 0; //the first point that the object will move towards is the transform at [0]
	private bool chasingPlayer;
	
	//for audio
	public float timerForAudio;
	public float PatrolAudioCooldown;
	public float ChaseAudioCooldown;
	public AudioSource GoombaPatrolSFX;
	public AudioSource GoombaChaseSFX;
	//public AudioSource GoombaDetectionSFX;
	public bool isChasing;


	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		isChasing = false;
	}
	//Every update, check if player is in range of object's detection range
	//if true = chase player, if false = patrol
	void FixedUpdate ()
	{
		chasingPlayer = CheckPlayerDetection();
		
		if (chasingPlayer)
		{
			Chase();
		}
		else
		{
			Patrol();
		}
		
		CapSpeed();
		
		Debug.DrawRay(transform.position, transform.forward, Color.yellow);
	}

	//Shoot raycast toward player to check if object has line of sight/is in range to see player
	bool CheckPlayerDetection()
	{
		Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.yellow);
		RaycastHit hitInfo;

		//if already chasing player, use increased range to prevent instant de-aggro
		if (chasingPlayer)
		{
			Physics.Raycast(transform.position, player.transform.position - transform.position, out hitInfo,
				maxChaseDist);
		} 
		else
		{
			Physics.Raycast(transform.position, player.transform.position - transform.position, out hitInfo, detectionDist);
		}

		//if raycast hits player, set chasingPlayer to true, else set it to false
		if (hitInfo.collider != null)
		{
			if (hitInfo.collider.transform == player)
			{
				//Enemy detection sfx
				//GoombaDetectionSFX.Play();
				return true;
			} 
			else
			{
				return false;
			}
		}
		return false;
	}

	//walk between patrol points when not chasing player
	//always starts with [0], walks in the order of the array, and loops
	void Patrol()
	{
		Vector3 patrolPosition = PatrolPoints[patrolIndex].position;
		patrolPosition.y = transform.position.y;
		Vector3 directionToNextPoint = (patrolPosition - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(patrolPosition - transform.position), rotationSpeed * Time.deltaTime);
		rb.AddForce(directionToNextPoint * moveSpeed);
		
		//audio
		//GoombaPatrolSFX.Play();
		if (timerForAudio > PatrolAudioCooldown)
		{
			GoombaPatrolSFX.Play();
			timerForAudio = 0;
		}

		if (Vector3.Distance(transform.position, PatrolPoints[patrolIndex].position) < 0.5)
		{
			patrolIndex++;
			if (patrolIndex >= PatrolPoints.Length)
			{
				patrolIndex = 0;
			}
		}

		timerForAudio += Time.deltaTime;

	}
	
	

	//if is chasingPlayer, move toward the player
	void Chase()
	{
		//audio
		//GoombaChaseSFX.Play();
		
		if (timerForAudio > ChaseAudioCooldown)
		{
			GoombaChaseSFX.Play();
			timerForAudio = 0;
		}
		
		timerForAudio += Time.deltaTime;
		
		GoombaChaseSFX.Play();

		Vector3 playerPos = player.transform.position;
		playerPos.y = transform.position.y;
		Vector3 directionToPlayer = (playerPos - transform.position).normalized;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPos - transform.position), rotationSpeed * Time.deltaTime);
		rb.AddForce(directionToPlayer * moveSpeed);
	}

	void CapSpeed()
	{
		float tempX = rb.velocity.x;
		float tempZ = rb.velocity.z;

		Vector3 tempV3 = new Vector3(tempX, 0, tempZ);

		if (!isChasing)
		{
			if (tempV3.magnitude > maxMoveSpeed)
			{
				Vector3 tempVNorm = tempV3.normalized * maxMoveSpeed;
				rb.velocity = new Vector3(tempVNorm.x, rb.velocity.y, tempVNorm.z);
			}
		} 
		else
		{
			{
				if (tempV3.magnitude > maxChaseSpeed)
				{
					Vector3 tempVNorm = tempV3.normalized * maxChaseSpeed;
					rb.velocity = new Vector3(tempVNorm.x, rb.velocity.y, tempVNorm.z);
				}
			} 
		}
	}
}
