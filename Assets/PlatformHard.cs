using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformHard : MonoBehaviour
{
    public Collider collider;
    bool shouldCheckForCollision = true;
    Vector3 zero = new Vector3(0, 0, 0);
    public bool stayStill;

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (Mathf.Abs(collider.bounds.center.x - other.gameObject.GetComponent<Collider>().bounds.center.x) <=
            collider.bounds.extents.x - other.gameObject.GetComponent<Collider>().bounds.extents.x && shouldCheckForCollision)
        {
            if (gameObject != null && (GameObject.Find("Ship").GetComponent<Rigidbody>().velocity == zero))
            {
                stayStill = true;
                yield return new WaitForSeconds(2.01f); // Fixes bug. Can't be less than 2
            }
            else if (gameObject == null && (GameObject.Find("Ship").GetComponent<Rigidbody>().velocity == zero))
            {
                stayStill = false;
            }
            else if (gameObject != null && (GameObject.Find("Ship").GetComponent<Rigidbody>().velocity != zero))
            {
                stayStill = false;
            }

            if (stayStill)
            {
                Debug.Log("You have LANDED!");
                shouldCheckForCollision = false;
                StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1000));  // Calls fucntion to add score (500 points - easy platform)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next level
            }
        }
    }

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