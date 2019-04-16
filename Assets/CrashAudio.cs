using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAudio : MonoBehaviour
{
/*  The crash audio must be implemented as a seperate game object because the
 *  ship object is destroyed immediately during the crash sequence. The audio
 *  can't play from an object tht doesn't exist!
*/
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
