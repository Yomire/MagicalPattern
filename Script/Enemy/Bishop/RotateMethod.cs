using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMethod : MonoBehaviour
{
    public float RotateZ = 1.0f;
    public string Flag, PauseFlag;

    void OnEnable()
    {
        if(PauseFlag == "Off")
        {
            PauseFlag = "On";
            Flag = "Null";
        }        
    }

    void Update()
    {
        if(Flag == "Rotate")
        {
            this.transform.Rotate(0.0f, 0.0f, RotateZ);
        }        
    }
    public void RotateEvent()
    {
        Flag = "Rotate";
    }
    public void PauseFlagOffMethod()
    {
        PauseFlag = "Off";
    }
}
