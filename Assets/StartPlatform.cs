using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2f)
        {
            StartCoroutine(GameObject.Find("Ship").GetComponent<Ship>().ShipGoBoom());                 // Calls function to blow up the ship
            StartCoroutine(GameObject.Find("CrashAudio").GetComponent<CrashAudio>().PlayCrashAudio()); // Calls function to play crash audio
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().TakeLife());     // Calls function to take a life away
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().Restart());      // Calls level restart function

            Debug.Log("You have CRASHED!");
        }
    }
}
