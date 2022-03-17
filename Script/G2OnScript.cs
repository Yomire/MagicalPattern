using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2OnScript : MonoBehaviour
{
    public Collider2D OnOffCol;
    void OnEnable()
    {
        OnOffCol.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground2On")
        {
            OnOffCol.enabled = true;
        }
    }
}
