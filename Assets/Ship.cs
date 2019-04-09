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
    public AudioSource source;
    public AudioClip thrusterAudio;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = thrusterAudio;
    }
    
    public IEnumerator ShipGoBoom()  //this function destroys the ship with an explosion effect
    {
        ParticleSystem explosionEffect = Instantiate(DestructionEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.loop = false;
        explosionEffect.Play();
        Destroy(explosionEffect.gameObject, explosionEffect.duration);
        Destroy(gameObject);

        yield return new WaitForSeconds(1);
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
 
        // Plays thruster audio when ship is moving
        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") != 0)
        {
            if(!source.isPlaying)
            {
                source.Play();
            }
        }
        else if(source.isPlaying)
        {
            source.Stop();
        }
    }
}
