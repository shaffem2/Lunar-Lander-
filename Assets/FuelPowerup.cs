using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Ship").GetComponent<Ship>().SetFuel(1);
        Destroy(this.gameObject);
    }
}
