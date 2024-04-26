using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Put on MainMenu game object
//will start the game
public class MainMenuScript : MonoBehaviour
{

	public void PlayGame()
	{
		SceneManager.LoadScene("LevelScene_1");
		AudioManager.Instance.StartGame();
		
	}

	public void StartOver()
	{
		SceneManager.LoadScene("MenuSceneMaybe");
		AudioManager.Instance.StartMenu();
		
	}
}
