using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: Put this on the second ? platform game object
//Intent: trigger for stairs to appear when Mario hits the FIRST ? Button
public class SecondQuestionBlockScript : MonoBehaviour {
	
	
	//The lifetime of the object
	public float lifetime = 18f;
	private bool canTrigger;
	public GameObject stairs;
	
	//for animation
	private Animator ButtonAnim;
	
	//public AudioSource TimerAudioSource;
	
	// Use this for initialization
	void Start ()
	{
		//gameobject starts level disabled
		
		//gameObject.GetComponent<Renderer>().enabled = false;
		
		ButtonAnim = GetComponent<Animator>();
		
		//have stairs not seen
		
		stairs.SetActive(false);
		
		//starts trigger as active to true
		canTrigger = true;
		
	}
	


// When player hits trigger, the platform appears
	void OnTriggerEnter(Collider other)
	{
		//if touched by player, it turns on & timer starts
		if(other.gameObject.tag == "Player" && canTrigger == true)
		{
			//turns trigger off/
			///turns off trigger temporarily
			GetComponent<Collider>().isTrigger = false;
			canTrigger = false;
			
			//goes to the Coroutine
			StartCoroutine(PlatformTimer());
			
			//Animation on
			ButtonAnim.SetBool("IsPressed", true);
			
			//activates object
			stairs.SetActive(true);
			
			
			//play audio
			//AudioManager.Instance.PlayAudioClip(AudioManager.Instance.Timer);
			//TimerAudioSource.Play();
			AudioManager.Instance.PlayTimerSound();
		}

	}

	//Timer that goes down each second
	IEnumerator PlatformTimer()
	{

		while (lifetime > 0)
		{
			yield return new WaitForSeconds(1);

			lifetime--;
		}

		//makes platforms not exist
		stairs.SetActive(false);
		
		//Animation off
		ButtonAnim.SetBool("IsPressed", false);
                       			
		//makes the trigger active again
		GetComponent<Collider>().isTrigger = true;
		canTrigger = true;
                       			
		//resets the counter
		lifetime = 18f;
		
		//TimerAudioSource.Stop();
                       			
		
	}	
}
