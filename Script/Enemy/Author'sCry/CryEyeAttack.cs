using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryEyeAttack : MonoBehaviour
{
    public GameObject StartPos;
    private Rigidbody2D rb;
    public float Speed = 0.0f, EndPos_X, EndPos_XB;
    public string PauseFlag;
    // Start is called before the first frame update
    void OnEnable()
    {
        this.transform.position = StartPos.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseFlag != "On")
        {
            if (rb != null)
            {
                rb.velocity = Vector2.right * Speed;
            }
            if (this.transform.localPosition.x >= EndPos_X)
            {
                Disable();
            }
            if (this.transform.localPosition.x <= EndPos_XB)
            {
                Disable();
            }
        }
        if (PauseFlag == "On")
        {
            rb.velocity = Vector3.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            PauseFlag = "On";
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            PauseFlag = "Off";
        }
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        this.transform.position = StartPos.transform.position;
        //CancelInvoke();
    }

    public void Destroy()
    {
        if(this.gameObject != null)
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
