using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public static int fuel;
    Text fuelText;


    // Start is called before the first frame update
    void Start()
    {
        fuelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fuelText.text = "Fuel: " + fuel; // Displays Fuel
    }
}

