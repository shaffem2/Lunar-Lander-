using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private void OnCollisionEnter() //if the ship collides with a wall, flag it within Ship.cs script
    {
        Ship.hasCollided = true;
    }
}