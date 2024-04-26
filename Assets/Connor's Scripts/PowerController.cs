using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script that controls the fill amount of the powercircle UI element.
// Put this on the GameManager object in the scene, and associate objects in the inspector
public class PowerController : MonoBehaviour
{
	public Image powercircle;

	public int health;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Pass the variable that controls health here, hopefully it's an int, but if it's not,
		// let me know and I'll help out
		health = marioHealthDeath.health;
		
		// Since there's only 1 thing this script does, we don't want update to be cluttered in
		// case something goes south and needs to be fixed
		CalculateFill();
	}

	// CalculateFill determines the fill amount and color of the powercircle based on
	// Mario's health, just like in SM64
	public void CalculateFill()
	{
		// So this is a band-aid more than anything, but basically, assigns fill and color based on the
		// int directly (I bet there's a better way to do it but I don't know how)
		if (health == 8)
		{
			powercircle.fillAmount = 1f;
			powercircle.color = Color.blue;
		}
		else if (health == 7)
		{
			powercircle.fillAmount = 0.92f;
			powercircle.color = Color.blue;
		}
		else if (health == 6)
		{
			powercircle.fillAmount = 0.78f;
			powercircle.color = Color.green;
		}
		else if (health == 5)
		{
			powercircle.fillAmount = 0.64f;
			powercircle.color = Color.green;
		}
		else if (health == 4)
		{
			powercircle.fillAmount = 0.48f;
			powercircle.color = Color.yellow;
		}
		else if (health == 3)
		{
			powercircle.fillAmount = 0.37f;
			powercircle.color = Color.yellow;
		}
		else if (health == 2)
		{
			powercircle.fillAmount = 0.23f;
			powercircle.color = Color.red;
		}
		else if (health == 1)
		{
			powercircle.fillAmount = 0.12f;
			powercircle.color = Color.red;
		}
		else if (health == 0)
		{
			powercircle.fillAmount = 0f;
			powercircle.color = Color.red;
		}
	}
}
