using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnableMute : MonoBehaviour
{
    public AudioSource audioSource, audioLoopEnable, audioLoop, EnableMute1;

    // Start is called before the first frame update
    void OnEnable()
    {
        audioSource.mute = true;
        EnableMute1.mute = true;
        Invoke("MuteFalse", 1.0f);
    }

    // Update is called once per frame
    public  void MuteFalse()
    {
        audioSource.mute = false;
        EnableMute1.mute = false;
    }
}
