using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColScript : MonoBehaviour
{
    public KnightScript KS;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            KS.SwingUpMethod();
        }
    }
}
