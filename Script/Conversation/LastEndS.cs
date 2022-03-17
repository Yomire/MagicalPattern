using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LastEndS : MonoBehaviour
{
    public Text StoryText;
    public AudioSource BGMASource;
    public void TextColorChange()
    {
        StoryText.color = new Color32(50, 50, 50, 255);
    }
    public void BGMMethod()
    {
        BGMASource.Play();
    }
}
