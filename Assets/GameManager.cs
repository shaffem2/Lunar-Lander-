using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int lives = 3;

    /*
    void Awake()  //This function stops the GameObject GameManager from being destroyed when a new scene is loaded or the scene is restarted upon death.
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    */

    public IEnumerator Restart()            // Level restart function
    {
        yield return new WaitForSeconds(2); // Waits 2 second

        if (lives < 0) // if there are no more lives left, load main menu and reset life counter
        {
            lives = 3;
            SceneManager.LoadScene("MainMenu");
            score = 0;
        }

        else
        {
            Scene currentScene = SceneManager.GetActiveScene(); // Restarts current level
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public IEnumerator AddScore(int amount) // Add an amount of score to the running score total
    {
        score = score + amount;
        yield return new WaitForSeconds(1); // Waits 1 second
    }

    public IEnumerator TakeLife()  //this function takes a life away
    {
        lives = lives - 1;
        Debug.Log("One Life Removed");
        yield return new WaitForSeconds(1.0f);  // Waits 1 second
    }
}
