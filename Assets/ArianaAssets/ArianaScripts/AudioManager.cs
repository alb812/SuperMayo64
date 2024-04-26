using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

//INTENT: Manages the Audio in the game
//Usage: Put this in the scene's Hierarchy
public class AudioManager : MonoBehaviour
{
	//sets the Monobehavior to null
	//By making this an instance, other scripts have access to it
	private static AudioManager instance = null;

	//Instantiates a prefab that allows sounds to be played
	[SerializeField] GameObject myPrefabSFX;
	//so other sounds dont interfere with the BGM!
	[SerializeField] GameObject MiscAudioPrefab;
	//so other sounds dont interfere with the BGM!
	public AudioSource MiscAudioSource;

	[SerializeField] private AudioSource BackgroundMusicAudioSource;
	[SerializeField] private AudioSource BackgroundMusicIntroAudioSource;
	[SerializeField] private AudioSource MainMenuMusicAudioSource;
	[SerializeField] private AudioSource GameOverMusicAudioSource;
	[SerializeField] private AudioSource YouWinMusicAudioSource;
	[SerializeField] private AudioSource MarioGameOverAudioSource;
	
	
	//[SerializeField] private AudioSource FootstepsAudioSource;

	public AudioClip BackgroundMusicIntro;
	public AudioClip MainMenuMusic;
	public AudioClip GameOverMusic;
	public AudioClip YouWinMusic;
	public AudioClip BackgroundMusic;

	[Header("NPC Sounds")]
	//Goomba Sounds
	public AudioClip GoombaWalkSounds;

	public AudioClip GoombaChargeSounds;
	public AudioClip GoombaAlertSound;
	public AudioClip GoombaDeathSound;

	//ElectricEnemy
	//public AudioClip ElecPatrolSounds;

	[Header("Mario Sounds")]
	//Walk/Land
	public AudioClip[] FootstepSounds;
	public AudioClip LandSound;

	//Jumps
	public AudioClip[] MarioJumpx1;
	public AudioClip MarioJumpx2;
	public AudioClip MarioJumpx3;
	public AudioClip[] MarioJumpSide;
	public AudioClip MarioJumpLong;
	public AudioClip MarioCrouch;
	public AudioClip MarioJumpBackflip;
	public AudioClip MarioJumpBackflipLand;
	public AudioClip[] MarioJumpWall;

	//Stagger/Hits/Clamber
	public AudioClip[] MarioStagger;
	public AudioClip MarioBurned;
	public AudioClip MarioGetUp;
	public AudioClip MarioNearlyFallClamber;
	public AudioClip MarioPullSelfUpLedge;
	public AudioClip MarioFallDeath;
	public AudioClip MarioLowHealthDeath;
	public AudioClip[] MarioLowHealth;
	public AudioClip MarioStar;
	public AudioClip MarioGameOver;

	[Header("CameraSounds")] public AudioClip CameraLeft;
	public AudioClip CameraRight;
	public AudioClip CameraIn;
	public AudioClip CameraOut;

	[Header("Level Sounds")]
	//Fire Trap
	//public AudioClip FireActivation;

	//Button Press
	public AudioClip Timer;

	//Coins
	public AudioClip YellowCoinPickUp;

	public AudioClip[] RedCoinPickUp;

	//Star
	public AudioClip StarAppear;
	public AudioClip StarGrabbed;

	//1 UP
	public AudioClip OneUPSpin;
	public AudioClip OneUPGrabbed;

	//Box
	public AudioClip boxOpened;

	// ===============================================Mixer Groups
	[Header("Mixer Groups")] public AudioMixerGroup SoundEffectSoundGroup;

	public AudioMixerGroup MainSoundGroup,
		NPCSoundGroup,
		MarioSoundGroup,
		MarioDyingSoundGroup,
		BoxSoundGroup,
		OneUpSoundGroup,
		RedCoinSoundGroup,
		FootstepsGroup,
		TimerMusicGroup,
		StarSoundGroup,
		IntroBGMMusicGroup,
		BowserRoadBGMMusicGroup,
		MiscMusicGroup;

	[Header("Mixer Snapshots")] public AudioMixerSnapshot menuMixerSnapshot;
	public AudioMixerSnapshot gameMixerSnapshot;


	//Singleton Pattern
	public static AudioManager Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		//checks to see if instance is not equal to null and Monobehavior is not equal to this
		//Basically makes sure that this is the instance and that there's only one
		//Keeps prefab in scene under "DontDestroyOnLoad"
		if (instance != null && instance != this)
		{
			//Will destroy the gameobject if there's another instance
			//Don't want another instance
			Destroy(this.gameObject);
		}
		else
		{
			//the instance becomes this Monobehavior
			instance = this;
		}

		//Prevents the prefab from being destroyed when level loads
		DontDestroyOnLoad(this.gameObject);
	}


	// Use this for initialization1
	void Start()
	{
		if (SceneManager.GetActiveScene().name == "MenuSceneMaybe")
		{
			StartMenu();
		}
		
		if(SceneManager.GetActiveScene().name == "LevelScene_1")
		{
		//Plays the intro when scene loads
			StartGame();
		}
	}
	
	public void PlayRandomFromArray(AudioClip[] audioClips)
	{
		//Picks a random SFX from the array and plays it 
		AudioClip toPlay = audioClips[Random.Range(0, audioClips.Length)];
		PlayAudioClip(toPlay);
	}

	public void PlayAudioClip(AudioClip toPlay)
	{
		//Plays SFX 
		//Change from Camera.main when you know the sound works!
		AudioSource.PlayClipAtPoint(toPlay, GameObject.FindWithTag("Player").transform.position);
		//AudioSource.PlayClipAtPoint(toPlay, Camera.main.transform.position);
		//Make audio source child on Mario - play oneshot on it. Stop current source before doing next, for voices. 
	}
	
	//====================================MIXER GROUPS========================
	//These route sounds to the right mixer so its not a mess
	public void PlayNPCSound()
	{
		//Plays a random site sound when we find a site (one of the large circles)
	}

	public void PlayFootstepSound()
	{
		AudioClip randomFootstepClip = FootstepSounds[Random.Range(0, FootstepSounds.Length)];
		Debug.Log("Playing Footstep");
		PlaySFX(randomFootstepClip, 1.0f, 0f, FootstepsGroup);
	}

	public void PlayMarioFallDeathSound()
	{

		//AudioClip randomActivateSiteClip = activateStationSounds[Random.Range(0, activateStationSounds.Length)];
		//PlaySFX(randomActivateSiteClip, 1.0f, 0f, MarioSoundGroup);
		
		if (MarioFallDeath != null)
		{
			PlaySFX(MarioFallDeath, 1.0f, 0f, MarioDyingSoundGroup);
		}
	}
	
	public void PlayMarioGrabStarSound()
	{

		//AudioClip randomActivateSiteClip = activateStationSounds[Random.Range(0, activateStationSounds.Length)];
		//PlaySFX(randomActivateSiteClip, 1.0f, 0f, MarioSoundGroup);
		
		if (MarioStar != null)
		{
			PlaySFX(MarioStar, 1.0f, 0f, MarioSoundGroup);
		}
		
		if (StarGrabbed != null)
		{
			PlaySFX(StarGrabbed, 1.0f, 0f,StarSoundGroup);
		}
	}

	public void PlayStarAppearedSound()
	{
		if (StarAppear != null)
		{
			
			PlaySFX(StarAppear, 1.0f, 0f, StarSoundGroup);
			
		}
	}
	
	
	public void PlayRedCoinSound()
	{

		AudioClip randomRedCoinClip = RedCoinPickUp[Random.Range(0, RedCoinPickUp.Length)];
		//
		PlaySFX(randomRedCoinClip, 1.0f, 0f, RedCoinSoundGroup);
	}

	public void PlayYellowCoinSound()
	{
		if (YellowCoinPickUp != null)
		{
			PlaySFX(YellowCoinPickUp, 1.0f, 0f, RedCoinSoundGroup);
		}
	}
	
	public void PlayTimerSound()
	{
		if (Timer != null)
		{
			PlaySFX(Timer, 1.0f, 0f, TimerMusicGroup);
		}
	}
	
	public void PlayBoxBreakSound()
	{
		if (boxOpened != null)
		{
			PlaySFX(boxOpened, 1.0f, 0f,BoxSoundGroup);
		}
	}
	
	public void PlayOneUpGrabbedSound()
	{
		if (OneUPGrabbed != null)
		{
			PlaySFX(OneUPGrabbed, 1.0f, 0f,OneUpSoundGroup);
		}
	}

//=================For Scene Changes

	public void StartMenu()
	{
		
		GameOverMusicAudioSource.Stop();
		YouWinMusicAudioSource.Stop();
		
		if (MainMenuMusic != null)
		{
			MainMenuMusicAudioSource.outputAudioMixerGroup = IntroBGMMusicGroup;
			MainMenuMusicAudioSource.PlayScheduled(AudioSettings.dspTime + 0.25f);
		}
	}

	public void StartGame()
	{
		MainMenuMusicAudioSource.Stop();
		
		if (BackgroundMusicIntro != null)
		{
			BackgroundMusicIntroAudioSource.outputAudioMixerGroup = IntroBGMMusicGroup;
			BackgroundMusicIntroAudioSource.PlayScheduled(AudioSettings.dspTime + 0.25f);
		}

		if (BackgroundMusicAudioSource != null && !BackgroundMusicAudioSource.isPlaying)
		{
			BackgroundMusicAudioSource.outputAudioMixerGroup = BowserRoadBGMMusicGroup;
			//Plays the background music after the intro plays
			BackgroundMusicAudioSource.PlayScheduled(AudioSettings.dspTime + 0.20f + BackgroundMusicIntro.length);	
		}
	}

	public void GameOver()
	{
		BackgroundMusicAudioSource.Stop();
		BackgroundMusicIntroAudioSource.Stop();
		
		if (GameOverMusic != null)
		{
			GameOverMusicAudioSource.outputAudioMixerGroup = IntroBGMMusicGroup;
			GameOverMusicAudioSource.Play();
		}

		if (MarioGameOver != null)
		{
			MarioGameOverAudioSource.outputAudioMixerGroup = BowserRoadBGMMusicGroup;
			//Plays the background music after the intro plays
			MarioGameOverAudioSource.PlayScheduled(AudioSettings.dspTime + 0.20f);	
		}
		
		
	}

	public void WinScene()
	{
		BackgroundMusicAudioSource.Stop();
		BackgroundMusicIntroAudioSource.Stop();
		
		if (YouWinMusic != null)
		{
			YouWinMusicAudioSource.outputAudioMixerGroup = IntroBGMMusicGroup;
			YouWinMusicAudioSource.Play();
		}
	}
	
	
	//================================================== Play SFX
	//This will instantiate the SFX prefab then destroy it after. Don't touch please. It's how the sound will work. 
     	public void PlaySFX (AudioClip g_SFX, float g_Volume, float g_Pan, AudioMixerGroup g_destGroup) {
     		GameObject t_SFX = Instantiate (myPrefabSFX) as GameObject;
     		t_SFX.name = "SFX_" + g_SFX.name;
		     //gets the audio clip
     		t_SFX.GetComponent<AudioSource> ().clip = g_SFX;
		     //gets the basic volume (can be adjusted in Mixer)
     		t_SFX.GetComponent<AudioSource> ().volume = g_Volume;
		     //sets the panning (just leave this at 0, we dont really need it for some things)
     		t_SFX.GetComponent<AudioSource> ().panStereo = g_Pan;
		     //Very important, tells which mixer group something is being sent to
     		t_SFX.GetComponent<AudioSource> ().outputAudioMixerGroup = g_destGroup;
		     //then it plays the sound
     		t_SFX.GetComponent<AudioSource> ().Play ();
		     //and here it gets destroyed woooo
     		DestroyObject(t_SFX, g_SFX.length);
     	}
}