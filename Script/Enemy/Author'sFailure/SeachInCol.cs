using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeachInCol : MonoBehaviour
{
    public FailureScript FScript;

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Player")
        {
            FScript.BladeMethod();
        }
    }
}
