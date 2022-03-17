using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public FailureScript FScript;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            FScript.DamageMethod();
        }
    }
    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            FScript.Damage2Method();
        }
    }
}
