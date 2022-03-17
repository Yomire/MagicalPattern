using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePosScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Ground" || trcol.gameObject.tag == "Boss")
        {
            this.gameObject.SetActive(false);
        }
    }
}
