using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int lives = 3;
    public static float fuel;


    public IEnumerator Restart()            // Level restart function
    {
        yield return new WaitForSeconds(2); // Waits 2 second

        if (lives < 0) // if there are no more lives left, load main menu and reset life counter
        {
            lives = 3;
            SceneManager.LoadScene("EndScreen");
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

    public static void ResetScore()
    {
        score = 0;
    }

    public IEnumerator CrashSequence()
    {
        StartCoroutine(GameObject.Find("Ship").GetComponent<Ship>().ShipGoBoom());                 // Calls function to blow up the ship
        StartCoroutine(GameObject.Find("CrashAudio").GetComponent<CrashAudio>().PlayCrashAudio()); // Calls function to play crash audio
        StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().TakeLife());     // Calls function to take a life away
        StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().Restart());      // Calls level restart function
        Debug.Log("You have CRASHED!");
        Ship.hasCollided = false;
        yield return new WaitForSeconds(1.0f);

    }
}
