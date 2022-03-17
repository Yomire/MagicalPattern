using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceColScript : MonoBehaviour
{
    public KnightScript KS;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            KS.LanceCountMethod();
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            KS.LanceCountMethod();
        }
    }
}
