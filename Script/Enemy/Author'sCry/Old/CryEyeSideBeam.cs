using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryEyeSideBeam : MonoBehaviour
{
    //public GameObject StartPos;
    private Rigidbody2D rb;
    public float Speed = 0.0f, EndPos_X, EndPos_XB;
    public string flag = "Start";
    public GameObject Laser;

    // Start is called before the first frame update
    void OnEnable()
    {
        //this.transform.position = StartPos.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Invoke("Back", 4.0f);
        Invoke("Disable", 6.0f);
        Laser.SetActive(false);
        flag = "Start";
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "Start")
        {
            if (rb != null)
            {
                rb.velocity = Vector2.right * Speed;
            }
            if (this.transform.localPosition.x >= EndPos_X)
            {
                flag = "Stop";
                //Disable();
            }
            if (this.transform.localPosition.x <= EndPos_XB)
            {
                flag = "Stop";
                //Disable();
            }
        }
        if(flag == "Stop")
        {
            rb.velocity = Vector2.right * 0;
            Laser.SetActive(true);
        }
        if(flag == "Back")
        {
            //Laser.SetActive(false);
            rb.velocity = Vector2.right * -Speed;
        }
    }

    public void Back()
    {
        //Debug.Log("test");
        flag = "Back";
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        //this.transform.position = StartPos.transform.position;
        CancelInvoke();
    }

    public void Destroy()
    {
        if (this.gameObject != null)
        {
            Shake();
            CoinGenerate();
            GameObject obj14 = ObjectPooler14.current.GetPooledObject();
            if (obj14 == null) return;
            obj14.transform.position = this.transform.position;
            obj14.SetActive(true);
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }

    void Shake()
    {
        ScreenShakeController.instance.StartShake(.2f, .1f);
    }

    void CoinGenerate()
    {
        GameObject obj20 = ObjectPooler20.current.GetPooledObject();
        if (obj20 == null) return;
        obj20.transform.position = this.transform.position;
        obj20.SetActive(true);
    }
}
