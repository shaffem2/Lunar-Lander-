using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int level;
    Text levelText;


    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponent<Text>();
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + level; //Displays level
    }
}
