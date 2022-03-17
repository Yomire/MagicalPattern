using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    public float SpeedX = 0.1f, SpeedXB = 0.1f, RotateZ = 1.0f;
    private Rigidbody2D rb;
    public string flag = "Plus";

    // Start is called before the first frame update
    void OnEnable()
    {
        flag = "Plus";
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, RotateZ);
        if (flag == "Plus")
        {
            rb.velocity = new Vector2(SpeedX, 0);
            Invoke("FlagMinus", 0.1f);
        }
        /*if (rb.velocity.x >= LimitNumber)
        {
            flag = "Minus";            
        }*/ 
        if (flag == "Minus")
        {
            rb.velocity -= new Vector2(SpeedXB, 0);
        }
    }

    public void FlagMinus()
    {
        flag = "Minus";
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        //Debug.Log("testB");
        if (trcol.gameObject.tag == "Ground")
        {
            Disable();
            Shake();
        }
        if (trcol.gameObject.tag == "Enemy")
        {
            Disable();
            Shake();
        }
        if (trcol.gameObject.tag == "Block")
        {
            Disable();
            Shake();
        }
        if (trcol.gameObject.tag == "Boss")
        {
            Disable();
            Shake();
        }
        if (trcol.gameObject.tag == "Ground2")
        {
            //sShake();
            Disable();
        }
        if (trcol.gameObject.tag == "Health-1")
        {
            Shake();
            Disable();
        }
    }
    /*void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("testA");
        if (col.gameObject.tag == "Ground")
        {
            Disable();
            Shake();
        }
        if (col.gameObject.tag == "Enemy")
        {
            Disable();
            Shake();
        }
        if (col.gameObject.tag == "Block")
        {
            Disable();
            Shake();
        }
        if (col.gameObject.tag == "Boss")
        {
            Shake();
            Disable();
        }
        if (col.gameObject.tag == "Ground2")
        {
            Shake();
            Disable();
        }
        if (col.gameObject.tag == "Health-1")
        {
            Shake();
            Disable();
        }
    }*/
    void Disable()
    {
        this.gameObject.SetActive(false);
        GameObject obj16 = ObjectPooler16.current.GetPooledObject();
        if (obj16 == null) return;
        obj16.SetActive(true);
        obj16.transform.position = this.transform.position;

    }
    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
