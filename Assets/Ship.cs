using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody rigidShip;
    public ParticleSystem BottomThruster;
    public ParticleSystem LeftThruster;
    public ParticleSystem RightThruster;
    public ParticleSystem DestructionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
           // if (GameObject.Find("Ship") != null)
           // {
           //     Explosion.Stop();
           // }
    }
    
    public IEnumerator ShipGoBoom()  //this function destroys the ship with an explosion
    {
        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                         as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it
        explosionEffect.loop = false;
        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(explosionEffect.gameObject, explosionEffect.duration);
        //destroy our game object
        Destroy(gameObject);
        yield return new WaitForSeconds(1);

    }
    //{
    //     GameObject expl = Instantiate(explosion2, transform.position, Quaternion.identity) as GameObject;
    //    Explosion.Play();
    //     Destroy(gameObject); // destroy the ship
    //     Destroy(expl, 3); // delete the explosion after 3 seconds
    //     yield return new WaitForSeconds(1);  // Waits 1 second
    // }

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
