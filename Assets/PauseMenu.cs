using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Need this to be able to switch scenes

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // Hit escape key to pause
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resumes the game if paused
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;        // Starts time again
        AudioListener.pause = false;
        IsPaused = false;
    }

    // Pauses the game
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;        // Stops time
        AudioListener.pause = true;
        IsPaused = true;
    }

    // Switches to Main Menu
    public void SwitchMainMenu()
    {
        Time.timeScale = 1f;        // Starts time again. Unnecessary atm because no objects on main menu interact with time. Here for safety purposes.
        AudioListener.pause = false;
        IsPaused = false;
        Debug.Log("Going to Main Menu!");
        GameManager.lives = 3; // Resets player lives when returning to Main Menu
        GameManager.score = 0; // Resets score when returning to Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
