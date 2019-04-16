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
    Vector3 zero = new Vector3(0, 0, 0);
    public static bool hasCollided = false;

    public void SetFuel(float value) //fucntion to set the fuel level mid game, used by fuel powerup
    {
        GameManager.fuel = value;
        fuelBar.value = value;
        return;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = thrusterAudio;
        SetFuel(1);
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
        if ((GameManager.fuel < 1) && (GameObject.Find("Ship").GetComponent<Rigidbody>().velocity == zero)) //refills fuel if ship is sitting still
        {
            GameManager.fuel += 0.8f * Time.deltaTime; //fuel fill
            fuelBar.value = GameManager.fuel;
        }

        if ((Input.GetAxis("Vertical") > 0.05f) && GameManager.fuel > 0)
        {
            rigidShip.AddForce(transform.up * 10.0f);   //move ship
            GameManager.fuel += -0.1f * Time.deltaTime; //fuel burn
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
            rigidShip.AddForce((transform.right * 6.0f) * Input.GetAxis("Horizontal")); //move ship
            GameManager.fuel += -0.1f * Time.deltaTime; //fuel burn
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

    private void Update()
    {
        if (hasCollided) //by checking if the ship has collided every frame, it prevents two collisions happening at once.
        {
            StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().CrashSequence()); //calls crash sequence function from gamemanager
        }
    }
}
