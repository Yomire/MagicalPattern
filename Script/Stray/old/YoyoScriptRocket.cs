using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoyoScriptRocket : MonoBehaviour
{
    public float SpeedY = 5.0f, SpeedYB = 0.1f, RotateZ = 1.0f;
    private Rigidbody2D rb;
    public string flag = "Plus";
    // Start is called before the first frame update
    void OnEnable()
    {
        flag = "Plus";
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, RotateZ);
        if (flag == "Plus")
        {
            rb.velocity = new Vector2(0, SpeedY);
            Invoke("FlagMinus", 0.1f);
        }
        /*if (rb.velocity.x >= LimitNumber)
        {
            flag = "Minus";            
        }*/
        if (flag == "Minus")
        {
            Invoke("Disable", 1.0f);
            rb.velocity -= new Vector2(0, SpeedYB);
        }
    }
    public void FlagMinus()
    {
        flag = "Minus";
        //rb.velocity = new Vector2(0, 0);
    }
    void Disable()
    {
        this.gameObject.SetActive(false);
        GameObject obj39 = ObjectPooler39.current.GetPooledObject();
        if (obj39 == null) return;
        obj39.SetActive(true);
        obj39.transform.position = this.transform.position;
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
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Ground2")
        {
            //sShake();
            Disable();
        }
    }
}
