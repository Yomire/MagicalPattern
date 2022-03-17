using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDamage : MonoBehaviour
{
    public TScript TS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            TS.BackMethod();
            TS.DamageMethod();
        }
    }
    void OnTriggerStay2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            TS.BackMethod();
            TS.Damage2Method();
        }
    }
}
