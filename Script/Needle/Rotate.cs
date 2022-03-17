using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateZ = 1.0f;
    public string PauseFlag;
    void Update()
    {
        if (PauseFlag != "On")
        {
            this.transform.Rotate(0.0f, 0.0f, RotateZ);
        }            
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
        }
    }
}
