using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUI : MonoBehaviour
{

	public static powerUI me;
	public Text powertext;
	

	// Use this for initialization
	void Start ()
	{

		

	}
	
	// Update is called once per frame
	void Update () {
		
		powertext.text = "Power: " + marioHealthDeath.health.ToString();
		
	}
	
	
}
