using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparcleColScript : MonoBehaviour
{
    public ParticleSystem SparclePar;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            SparclePar.Play();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            SparclePar.Stop();
        }
    }
}
