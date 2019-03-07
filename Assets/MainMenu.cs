using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        // Grabs the first scene in the queue to start game (Check: FILE >> BUILD SETTINGS for queue)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame() //
    {
        Debug.Log("GAME HAS CLOSED!");  // Debugger for Unity testing only to show that the game would exit normally
        Application.Quit();             // Exits game
    }
}
