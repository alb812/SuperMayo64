using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starsUI : MonoBehaviour
{

	public static starsUI me;
	public static int starsfound = 0;
	public Text startext;

	// Use this for initialization
	void Start ()
	{

		me = this;

	}
	
	// Update is called once per frame
	void Update ()
	{

		//startext.text = "Stars: " + starsfound.ToString();
		

	}
	
	//audio effect for getting stars here?
	public void FoundAStar()
	{
		starsfound++;
	}
}
