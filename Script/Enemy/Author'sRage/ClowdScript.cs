using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClowdScript : MonoBehaviour
{
    public float ScrollSpeed = 7.0f, EndPosX;
    public Rigidbody2D rb;
    public GameObject EnablePos;
    /*
    private void OnEnable()
    {
        this.transform.position = EnablePos.transform.position;
    }
    */
    void Update()
    {
        //transform.Translate(-speed, 0, 0);
        rb.velocity = Vector2.left * ScrollSpeed;

        if (this.transform.localPosition.x <= EndPosX)
        {
            this.transform.position = EnablePos.transform.position;
            if(EnablePos.activeSelf == false)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
