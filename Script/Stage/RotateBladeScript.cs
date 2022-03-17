using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBladeScript : MonoBehaviour
{
    public float SpeedX = 7.0f, SpeedY = 0.0f;
    public float DestroyTime = 7.0f;
    public float RotateZ = 1.0f;
    private Rigidbody2D rb;
    public string flag = "Null";
    public GameObject Sparkle;

    private void OnEnable()
    {
        flag = "Null";
        rb = GetComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Dynamic;
        //rb.gravityScale = 1;
        //Invoke("Disable", DestroyTime);
        //rb.velocity = new Vector2(0.0f, Jump);
        if(Sparkle != null)
        {
            Sparkle.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (flag == "Null")
        {
            this.transform.Rotate(0.0f, 0.0f, RotateZ);
            rb.velocity = new Vector2(SpeedX, SpeedY);
        }

        if (flag == "joint")
        {
            rb.velocity = Vector2.zero;
            this.transform.Rotate(0.0f, 0.0f, 0.0f);
            if (Sparkle != null)
            {
                Sparkle.gameObject.SetActive(false);
            }
        }
        if (this.transform.localPosition.x <= -5 || this.transform.localPosition.y <= -10)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Disable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
        Invoke("DisableEffect", 0.01f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (flag == "Null")
        {
            if (col.gameObject.tag == "Joint")
            {
                //Debug.Log("joint");
                flag = "joint";
                this.transform.parent = col.transform;
                //myRenderer.sortingOrder = (int)(sortingOrderNew);
            }
        }

        if (col.gameObject.tag == "JointRelease")
        {
            this.transform.parent = null;
            //Debug.Log(this.transform.parent);
            flag = "true";
            Invoke("DisableMethod", 0.01f);
        }
    }

    void DisableEffect()
    {
        GameObject obj13 = ObjectPooler13.current.GetPooledObject();
        if (obj13 == null) return;
        obj13.transform.position = this.transform.position;
        obj13.SetActive(true);
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
