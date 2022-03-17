using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPortalBlade : MonoBehaviour
{
    public string Flag, PauseFlag;
    public float StartPosX, StartPosY, MoveY;
    public AudioClip EnableClip;
    public AudioSource SEASource;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if(PauseFlag == "Off")
        {
            Flag = "Enable";
            PauseFlag = "On";
            SEASource.clip = EnableClip;
            SEASource.Play();
        }
    }

    void FixedUpdate()
    {
        this.transform.Translate(0, MoveY, 0);
        if (this.transform.localPosition.y >= 8)
        {
            SEASource.clip = EnableClip;
            SEASource.Play();
            this.transform.localPosition = new Vector3(StartPosX, StartPosY, 0);
            if (Flag == "Disable")
            {
                if (this.gameObject.activeSelf)
                {
                    PauseFlag = "Off";
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    public void DisableMethod()
    {
        Flag = "Disable";
    }
}
