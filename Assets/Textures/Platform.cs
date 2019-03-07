using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2f && shouldCheckForCollision)
        {
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().Restart()); // Calls level restart function
            Destroy(collision.gameObject);
            Debug.Log("You have CRASHED!");
        }
    }

}