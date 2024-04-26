using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using System.Timers;
using UnityEngine;


//USAGE: Put this on the 1st ? button platform game object
//Intent: trigger for invisible platform to appear when Mario hits the FIRST ? Button
public class FirstQuestionButtonScript : MonoBehaviour
{
	//The lifetime of the object
	public float lifetime = 18f;
	private bool canTrigger;
	public GameObject invisplat1, invisplat2;
	
	//for animation
	private Animator ButtonAnim;
	
	//public AudioSource TimerAudioSource;
	
	// Use this for initialization
	void Start ()
	{
		//gameobject starts level disabled
		
		//gameObject.GetComponent<Renderer>().enabled = false;
		
		invisplat1.SetActive(false);
		invisplat2.SetActive(false);

		ButtonAnim = GetComponent<Animator>();
		
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
			invisplat1.SetActive(true);
			invisplat2.SetActive(true);
			
			//play audio
			//AudioManager.Instance.PlayAudioClip(AudioManager.Instance.Timer);
			AudioManager.Instance.PlayTimerSound();
			//TimerAudioSource.Play();
		}

	}

	private void Update()
	{
		//when the blocks life hits 0, the object goes back to 0, and timer resets
		if (lifetime == 0)
		{
			
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
        invisplat1.SetActive(false);
        invisplat2.SetActive(false);
		
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
