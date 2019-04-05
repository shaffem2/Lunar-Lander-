using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAudio : MonoBehaviour
{
    public AudioClip crashAudio;
    private AudioSource source;

    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    public IEnumerator PlayCrashAudio()  //this function plays the crash audio
    {
        source.PlayOneShot(crashAudio);

        yield return new WaitForSeconds(1);

    }
}
