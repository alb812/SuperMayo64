using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class coinsUI : MonoBehaviour {
	//usage: put on a cylinder with a trigger
	//intent: destroy coin on collision, and add to a counter
	
	//making a singleton!!
	public static coinsUI me;
	
	public GameObject cointext1;
	public GameObject cointext2;
	public Sprite[] marioText;
	//public Collider coincollider;
	public static int coinsfound = 0;
	private int redcoinsfound;
	public int redCoinsForStar = 8; //number of red coins needed for star to appear

	public GameObject redCoinsStar; //star that activate when collecting all red coins
									 //the star should be placed in the scene, but set inactive to start
	
	// Use this for initialization
	void Start ()
	{
		me = this;

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (coinsfound >= 0 && coinsfound < 10)
		{
			cointext1.GetComponent<Image>().sprite = marioText[coinsfound];
			cointext2.SetActive(false);
		} 
		else if (coinsfound >= 10 && coinsfound < 100)
		{
			int tensDigit = coinsfound / 10;
			Debug.Log(tensDigit);
			int onesDigit = coinsfound - (tensDigit * 10);
			Debug.Log(onesDigit);
			cointext1.GetComponent<Image>().sprite = marioText[tensDigit];
			cointext2.SetActive(true);
			cointext2.GetComponent<Image>().sprite = marioText[onesDigit];
		}

	}

/*	private void OnTriggerEnter(Collider coincollider)
	{
		coinsfound++;
		cointext.text = "Coins: " + coinsfound.ToString();
		Destroy(GameObject.FindGameObjectWithTag("coin"));
	}*/
	
	//new void can be anything as long as it gets referenced in another script
	//you could put anything here and it'll change the way coins function 
	//if there's a coin-grabbing sound effect, put it here
	public void FoundACoin()
	{
		coinsfound++;
	}

	//increase red coins found whenever the player picks up a red coin
	public void FoundRedCoin()
	{
		redcoinsfound++;
		if (redcoinsfound >= redCoinsForStar) //if the player has found enough red coins for the star, set it to active
		{
			AudioManager.Instance.PlayStarAppearedSound();
			redCoinsStar.SetActive(true);
		}
	}
}
