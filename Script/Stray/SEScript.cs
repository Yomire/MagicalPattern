using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEScript : MonoBehaviour
{
    public AudioClip Sound1, Sound2, Sound3, Sound4, Sound5, Sound6, Sound7, Sound8, Sound9, Sound10, Sound11;
    public AudioSource audioSource, audioLoopEnable, audioLoop, PauseSupportAudio;

    // Start is called before the first frame update
    /*void OnEnable()
    {        
        if (EnableSound != null)
        {
            audioSource.PlayOneShot(EnableSound);
        }
        if (audioLoopEnable != null)
        {
            audioLoopEnable.Play();
        }
    }

    public void SoundLoopMethod()
    {
        if(audioLoop != null)
        {
            audioLoop.Play();
        }        
    }
    public void SoundLoopStopMethod()
    {
        if (audioLoop != null)
        {
            audioLoop.Stop();
        }
    }*/

    public void SoundMethod1()
    {
        audioSource.PlayOneShot(Sound1);
    }
    public void SoundMethod2()
    {
        audioSource.PlayOneShot(Sound2);
    }
    public void SoundMethod3()
    {
        audioSource.PlayOneShot(Sound3);
    }
    public void SoundMethod4()
    {
        audioSource.PlayOneShot(Sound4);
    }
    public void SoundMethod5()
    {
        audioSource.PlayOneShot(Sound5);
    }
    public void SoundMethod6()
    {
        audioSource.PlayOneShot(Sound6);
    }
    public void SoundMethod7()
    {
        audioSource.PlayOneShot(Sound7);
    }
    public void SoundMethod8()
    {
        audioSource.PlayOneShot(Sound8);
    }
    public void SoundMethod9()
    {
        audioSource.PlayOneShot(Sound9);
    }
    public void SoundMethod10()
    {
        PauseSupportAudio.PlayOneShot(Sound10);
    }
    public void SoundMethod11()
    {
        PauseSupportAudio.PlayOneShot(Sound11);
    }
}
