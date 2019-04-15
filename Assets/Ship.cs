using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Rigidbody rigidShip;
    public ParticleSystem BottomThruster;
    public ParticleSystem LeftThruster;
    public ParticleSystem RightThruster;
    public ParticleSystem DestructionEffect;
    public AudioSource source;
    public AudioClip thrusterAudio;
    public Slider fuelBar;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = thrusterAudio;
        GameManager.fuel = 1.0f;
        fuelBar.value = GameManager.fuel;
    }
    
    public IEnumerator ShipGoBoom()  //this function destroys the ship with an explosion effect
    {
        ParticleSystem explosionEffect = Instantiate(DestructionEffect) as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        explosionEffect.loop = false;
        explosionEffect.Play();
        Destroy(explosionEffect.gameObject, explosionEffect.duration);
        Destroy(gameObject);

        yield return new WaitForSeconds(0);
    }


    private void FixedUpdate()
    {
        if ((Input.GetAxis("Vertical") > 0.05f) && GameManager.fuel > 0)
        {
            rigidShip.AddForce(transform.up * 10.0f);
            GameManager.fuel += -0.1f * Time.deltaTime;
            fuelBar.value = GameManager.fuel;

            if(!BottomThruster.isPlaying)
            {
                BottomThruster.Play();
            }
        }

        else if (BottomThruster.isPlaying)
        {
            BottomThruster.Stop();
        }


        if ((Input.GetAxis("Horizontal") > 0.01f || Input.GetAxis("Horizontal") < -0.01f) && GameManager.fuel > 0)
        {
            rigidShip.AddForce((transform.right * 6.0f) * Input.GetAxis("Horizontal"));
            GameManager.fuel += -0.1f * Time.deltaTime;
            fuelBar.value = GameManager.fuel;

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
        if((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") != 0) && GameManager.fuel > 0)
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
