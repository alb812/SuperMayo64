using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is attached to an invisible trigger within the Pipe gameobject.
// This is called once the victory condition is met: Mario jumps into the pipe at the end of the level
// It reliquishes player control, then shortly transitions to the Victory Scene.

public class Pipe_Finale : MonoBehaviour {

    private Mario_Controller player;
    public AudioSource PipeSound;

	void Start ()
    {
        player = FindObjectOfType<Mario_Controller>();
	}

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WinGame());
        }
    }

    IEnumerator WinGame()
    {
        // SOUND: Play going down pipe sound
        PipeSound.Play();

        // Disable Player control
        player.isControllable = false;

        // Transition to Victory Scene
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("YouWinScene");
        AudioManager.Instance.WinScene();
        //SceneManager.LoadScene("VictoryScene");
    }
}
