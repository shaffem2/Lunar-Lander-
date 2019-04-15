using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesGUI : MonoBehaviour
{
    TextMeshProUGUI livesText;


    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();

        {
            if (GameManager.lives < 0)
            {
                livesText.text = "Lives: 0";                    //Prevents the lives counter from going negative
            }

            else
            {
                livesText.text = "Lives: " + GameManager.lives; //Displays level
            }
        }
    }
}
