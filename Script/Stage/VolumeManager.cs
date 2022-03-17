using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class VolumeManager : MonoBehaviour
{
    public Info1 info;
    public AudioSource SEASource1, SEASource2, SEASource3, SEASource4, SEASource5, SEASource6, SEASource7, SEASource8, SEASource9, SEASource10,
        SEASource11, SEASource12, SEASource13, SEASource14, SEASource15, SEASource16, SEASource17, SEASource18, SEASource19, SEASource20;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "scoreData" + ".json"))
        {
            info = JsonData.Load<Info1>("scoreData");
        }
        if(SEASource1 != null)
        {
            SEASource1.volume = info.SEVolume;
        }
        if (SEASource2 != null)
        {
            SEASource2.volume = info.SEVolume;
        }        
        if (SEASource3 != null)
        {
            SEASource3.volume = info.SEVolume;
        }
        if (SEASource4 != null)
        {
            SEASource4.volume = info.SEVolume;
        }
        if (SEASource5 != null)
        {
            SEASource5.volume = info.SEVolume;
        }
        if (SEASource6 != null)
        {
            SEASource6.volume = info.SEVolume;
        }
        if (SEASource7 != null)
        {
            SEASource7.volume = info.SEVolume;
        }
        if (SEASource8 != null)
        {
            SEASource8.volume = info.SEVolume;
        }
        if (SEASource9 != null)
        {
            SEASource9.volume = info.SEVolume;
        }
        if (SEASource10 != null)
        {
            SEASource10.volume = info.SEVolume;
        }
        if (SEASource11 != null)
        {
            SEASource11.volume = info.SEVolume;
        }
        if (SEASource12 != null)
        {
            SEASource12.volume = info.SEVolume;
        }
        if (SEASource13 != null)
        {
            SEASource13.volume = info.SEVolume;
        }
        if (SEASource14 != null)
        {
            SEASource14.volume = info.SEVolume;
        }
        if (SEASource15 != null)
        {
            SEASource15.volume = info.SEVolume;
        }
        if (SEASource16 != null)
        {
            SEASource16.volume = info.SEVolume;
        }
        if (SEASource17 != null)
        {
            SEASource17.volume = info.SEVolume;
        }
        if (SEASource18 != null)
        {
            SEASource18.volume = info.SEVolume;
        }
        if (SEASource19 != null)
        {
            SEASource19.volume = info.SEVolume;
        }
        if (SEASource20 != null)
        {
            SEASource20.volume = info.SEVolume;
        }        
    }
}
