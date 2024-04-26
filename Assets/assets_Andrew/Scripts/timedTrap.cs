using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedTrap : MonoBehaviour
{

	public GameObject trapCollider;
	public float cycleTime;
	private float cycleTimer;
	public float timeActive;
	private float activeTimer;
	private bool isActive = false;

	private ParticleSystem particleSys;
	
	//for audio
	public AudioSource FireActivationSFX;

	void Start()
	{
		particleSys = GetComponent<ParticleSystem>();
		cycleTimer = cycleTime;
	}
	
	void Update () {
		CycleTimer();
		if (isActive)
		{
			ActiveTimer();
			//AudioManager.Instance.PlayAudioClip(AudioManager.Instance.FireActivation);
			
		}
	}

	void CycleTimer()
	{
		cycleTimer += Time.deltaTime;
		if (cycleTimer >= cycleTime)
		{
			Activate();
		}
	}

	void Activate()
	{
		cycleTimer = 0;
		activeTimer = 0;
		isActive = true;
		var emission = particleSys.emission;
		emission.enabled = true;
		//Audio
		FireActivationSFX.Play();
		
		trapCollider.SetActive(true);
		//AudioManager.Instance.PlayFireActivationSound();
	}
	
	void ActiveTimer()
	{
		activeTimer += Time.deltaTime;
		if (activeTimer >= timeActive)
		{
			isActive = false;
			var emission = particleSys.emission;
			emission.enabled = false;
			
			//Audio
			//FireActivationSFX.Stop();
			
			trapCollider.SetActive(false);
		}
	}
}
