using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{
    public ExtendHand EScript;
    public Player PScript;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = this.gameObject.transform;
            EScript.UnExtendMethod();
            PScript.DamageMotion();
        }

        if (col.gameObject.tag == "Attack")
        {
            EScript.UnExtendMethod();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = this.gameObject.transform;
            EScript.UnExtendMethod();
            PScript.DamageMotion();
        }

        if (col.gameObject.tag == "Attack")
        {
            EScript.UnExtendMethod();
        }
    }
}
