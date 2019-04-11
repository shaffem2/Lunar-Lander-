using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    Text lives;


    // Start is called before the first frame update
    void Start()
    {
        lives = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().lives < 0)
        {
            lives.text = "Lives: 0";                        //Prevents the life counter from going negative
        }

        else
        {
            lives.text = "Lives: " + GameObject.Find("GameManager").GetComponent<GameManager>().lives; //Displays level
        }
    }
}