using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    public static int level;
    TextMeshProUGUI levelText;


    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level: " + level; //Displays level
    }
}
