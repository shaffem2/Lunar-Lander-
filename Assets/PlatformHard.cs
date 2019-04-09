using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformHard : MonoBehaviour
{
    public bool isStartingPlatform = false;
    public Collider collider;
    bool shouldCheckForCollision = true;

    private void OnTriggerStay(Collider other)
    {
        if (isStartingPlatform) return;

        if (Mathf.Abs(collider.bounds.center.x - other.gameObject.GetComponent<Collider>().bounds.center.x) <= collider.bounds.extents.x - other.gameObject.GetComponent<Collider>().bounds.extents.x && shouldCheckForCollision)
        {
            Debug.Log("You have LANDED!");
            shouldCheckForCollision = false;
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1000)); // Calls fucntion to add score (1000 points - hard platform)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next level
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2f && shouldCheckForCollision)
        {
            StartCoroutine(GameObject.Find("Ship").GetComponent<Ship>().ShipGoBoom());                 // Calls function to blow up the ship
            StartCoroutine(GameObject.Find("CrashAudio").GetComponent<CrashAudio>().PlayCrashAudio()); // Calls function to play crash audio
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().TakeLife());     // Calls function to take a life away
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().Restart());      // Calls level restart function
            //Destroy(collision.gameObject);
            Debug.Log("You have CRASHED!");
        }
    }

}