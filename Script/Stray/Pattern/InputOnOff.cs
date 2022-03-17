using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOnOff : MonoBehaviour
{
    LockPattern script;

    void Start()
    {
        script = GameObject.Find("Grid").GetComponent<LockPattern>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PatternOn")
        {
            script.InputResetMethod();
        }
    }

    /*void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Pause")
        {
            Pauser.Resume();
            script.InputResetMethod();
        }
    }*/
}
