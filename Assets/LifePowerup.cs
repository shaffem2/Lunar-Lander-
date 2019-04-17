using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerup : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GameManager.lives = (GameManager.lives + 1);
        GameObject.Find("LivesText").GetComponent<LivesGUI>().updateLives();
        this.gameObject.GetComponent<Renderer>().enabled = false;
        //Destroy(this.gameObject);
    }
}
