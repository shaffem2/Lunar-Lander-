using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool isStartingPlatform = false;
    public Collider collider;
    bool shouldCheckForCollision = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0f && shouldCheckForCollision)
        {
            StartCoroutine(GameObject.Find("Ship").GetComponent<Ship>().ShipGoBoom());              // Calls function to blow up the ship
            StartCoroutine(GameObject.Find("PlayerLives").GetComponent<PlayerLives>().TakeLife());  // Calls function to take a life away
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().Restart());   // Calls level restart function
            //Destroy(collision.gameObject);
            Debug.Log("You have CRASHED!");
        }
    }


}