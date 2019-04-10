using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Need this to be able to switch scenes
using UnityEngine.UI;

public class SecretMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject secretMenu;
    //public InputField input;
    private string inputString;
    private int inputNum;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // Hit escape key to pause
        {
            if (IsPaused)
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
        secretMenu.SetActive(false);
        Time.timeScale = 1f;        // Starts time again
        AudioListener.pause = false;
        IsPaused = false;
    }

    // Pauses the game
    public void Pause()
    {
        secretMenu.SetActive(true);
        Time.timeScale = 0f;        // Stops time
        AudioListener.pause = true;
        IsPaused = true;
    }

    public void chooseLevel(InputField input)
    {
        //input = gameObject.GetComponent<InputField>();
        inputString = input.text;
        inputNum = int.Parse(inputString);
        if (inputNum < 12 && inputNum > 0)
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            IsPaused = false;
            SceneManager.LoadScene(inputNum);
        }
        else
        {
            return;
        }
    }
}