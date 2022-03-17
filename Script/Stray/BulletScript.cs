using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float SpeedX = 5.0f;
    public float DisableTime = 5.0f;

    private void OnEnable()
    {
        Invoke("Disable", DisableTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(SpeedX, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
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
            //Shake();
            Disable();
        }
        if (col.gameObject.tag == "Health-1")
        {
            Shake();
            Disable();
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Shake();
        Disable(); 
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
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
            //Shake();
            Disable();
        }
        if (trcol.gameObject.tag == "Health-1")
        {
            Shake();
            Disable();
        }
        if (trcol.gameObject.tag == "DestroyEnemy")
        {
            Shake();
            Disable();
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
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
            //Debug.Log("testa");
            //Shake();
            Disable();
        }
        if (trcol.gameObject.tag == "Health-1")
        {
            Shake();
            Disable();
        }
    }

    void Disable()
    {
        this.gameObject.SetActive(false);
        GameObject obj16 = ObjectPooler16.current.GetPooledObject();
        if (obj16 == null) return;
        obj16.SetActive(true);
        obj16.transform.position = this.transform.position;

    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Shake()
    {
        //Debug.Log("test");
        ScreenShakeController.instance.StartShake(.1f, .05f);
    }
}
