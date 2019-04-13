using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    Text livesText;


    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().lives < 0)
        {
            livesText.text = "Lives: 0";                        //Prevents the lives counter from going negative
        }

        else
        {
            livesText.text = "Lives: " + GameObject.Find("GameManager").GetComponent<GameManager>().lives; //Displays level
        }
    }
}
