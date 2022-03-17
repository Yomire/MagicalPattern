using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ScrollSpeed = 7;

    void Update()
    {
        //transform.Translate(-speed, 0, 0);
        rb.velocity = Vector2.left * ScrollSpeed;
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "JointRelease" || trcol.gameObject.tag == "AttackSPB")
        {
            Invoke("DisableMethod", 0.01f);
            //LevelGenerateScript.instance.DisableCountMethod();
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
