using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ScrollSpeed, EndPosX;
    
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * ScrollSpeed;
        if (this.transform.localPosition.x <= EndPosX)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
