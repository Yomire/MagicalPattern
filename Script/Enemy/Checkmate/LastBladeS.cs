using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBladeS : MonoBehaviour
{
    public float SizeX, SizeY;
    public void LBSEnable()
    {
        SizeX = 0;
        SizeY = 0;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            SizeX += 0.5f;
            SizeY += 0.5f;
            transform.localScale = new Vector3(0.1f + SizeX, 0.4f + SizeY, 1);
            //Debug.Log("scale");
        }
    }
}
