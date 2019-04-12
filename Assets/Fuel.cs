using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public static int fuelValue;
    Text fuel;


    // Start is called before the first frame update
    void Start()
    {
        fuel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fuel.text = "Score: " + fuelValue; //Displays Fuel
    }
}

