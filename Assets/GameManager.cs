using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public IEnumerator Restart()           // Level restart function
    {
        yield return new WaitForSeconds(1.0f);  // Waits 1 second
        SceneManager.LoadScene("Game");         // Reloads "Game" scene
    }
}
