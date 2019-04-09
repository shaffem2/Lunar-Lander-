using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;

    void Awake()  //This function stops the GameObject PlayerLives from being destroyed when a new scene is loaded or the scene is restarted upon death.
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("playerlives");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator TakeLife()  //this function takes a life away
    {
        lives = lives - 1;
        Debug.Log("One Life Removed");
        yield return new WaitForSeconds(1.0f);  // Waits 1 second
    }
}
