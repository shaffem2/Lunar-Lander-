using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fuel : MonoBehaviour
{
    public static int fuel;
    TextMeshProUGUI fuelText;


    // Start is called before the first frame update
    void Start()
    {
        fuelText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        fuelText.text = "Fuel: " + fuel; // Displays Fuel
    }
}
