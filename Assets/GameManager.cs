using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public IEnumerator Restart()            // Level restart function
    {
        yield return new WaitForSeconds(2); // Waits 3 seconds  

        if (GameObject.Find("PlayerLives").GetComponent<PlayerLives>().lives < 0) //if there are no more lives left, load main menu and reset life counter
        {
            GameObject.Find("PlayerLives").GetComponent<PlayerLives>().lives = 3;
            SceneManager.LoadScene("MainMenu");
        }

        else
        {
            Scene currentScene = SceneManager.GetActiveScene(); //restarts current level
            SceneManager.LoadScene(currentScene.buildIndex);
        }


    }
}
