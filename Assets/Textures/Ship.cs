using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody rigidShip;
    public ParticleSystem BottomThruster;
    public ParticleSystem LeftThruster;
    public ParticleSystem RightThruster;
    public ParticleSystem Explosion;
    public GameObject explosion2; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Ship") != null)
        {
            Explosion.Stop();
        }
    }

    public IEnumerator ShipGoBoom()  //this function destroys the ship with an explosion
    {
        GameObject expl = Instantiate(explosion2, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject); // destroy the ship
        Destroy(expl, 3); // delete the explosion after 3 seconds
        yield return new WaitForSeconds(1.0f);  // Waits 1 second
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0.01f)
        {
            rigidShip.AddForce(transform.up * 10.0f);

            if(!BottomThruster.isPlaying)
            {
                BottomThruster.Play();
            }
        }

        else if (BottomThruster.isPlaying)
        {
            BottomThruster.Stop();
        }


        if (Input.GetAxis("Horizontal") > 0.01f || Input.GetAxis("Horizontal") < -0.01f)
        {
            rigidShip.AddForce((transform.right * 6.0f) * Input.GetAxis("Horizontal"));

            if (!LeftThruster.isPlaying && Input.GetAxis("Horizontal") > 0.01f)
            {
                LeftThruster.Play();
            }

            else if(!RightThruster.isPlaying && Input.GetAxis("Horizontal") < -0.01f)
            {
                RightThruster.Play();
            }
        }

        if (LeftThruster.isPlaying && Input.GetAxis("Horizontal") < 0.01f)
        {
            LeftThruster.Stop();
        }

        else if (RightThruster.isPlaying && Input.GetAxis("Horizontal") > -0.01f)
        {
            RightThruster.Stop();
        }


    }
}
