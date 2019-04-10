using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    public static int levelValue=1;
    Text lvl;


    // Start is called before the first frame update
    void Start()
    {
        lvl = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lvl.text = "Level: " + levelValue; //Displays level
    }
}
