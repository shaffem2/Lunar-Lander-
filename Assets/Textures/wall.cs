using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public bool isStartingPlatform = false;
    public Collider collider;
    bool shouldCheckForCollision = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > .001f && shouldCheckForCollision)
        {
            StartCoroutine(GameObject.Find("PlayerLives").GetComponent<PlayerLives>().TakeLife());  // Calls function to take a life away
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().Restart());   // Calls level restart function
            
            Destroy(collision.gameObject);
            Debug.Log("You have CRASHED!");
        }
    }


}