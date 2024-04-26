using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class livesUI : MonoBehaviour {
	//usage: put this on an empty called gamemanager
	//intent: decrease lives when mario dies

	public static livesUI me;
	public GameObject livestext;
	public static int liveslived = 3;
	public Sprite[] marioText;
	
	//for audio
	public float timerForGameOver = 3f;

	// Use this for initialization
	void Start ()
	{
		me = this;
		liveslived = 3;

	}
	
	// Update is called once per frame
	void Update ()
	{

		livestext.GetComponent<Image>().sprite = marioText[liveslived];

	}

	public void GainALife()
	{
		liveslived++;
	}
	
	//new void can be anything as long as it gets referenced in another script
	//you could put anything here and it'll change the way lives function 
	public void LostALife()
	{
		liveslived--;

		if (liveslived == 0)
		{
				SceneManager.LoadScene("DeathScene");
				AudioManager.Instance.GameOver();
				//liveslived = 3;
		}
	}
}
