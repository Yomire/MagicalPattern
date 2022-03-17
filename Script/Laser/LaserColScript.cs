using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColScript : MonoBehaviour
{
    public float Horizon = 1.0f;
    public float DisableTime = 5.0f;
    public GameObject EndPosObj;
    //private Rigidbody2D rb;

    private void OnEnable()
    {
        EndPosObj = GameObject.Find("EndPos");
        if(EndPosObj != null)
        {
            if (this.transform.localPosition.x >= EndPosObj.transform.localPosition.x)
            {
                Disable();
            }
        }
        this.transform.Translate(Horizon, 0, 0);
        Invoke("Disable", DisableTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        EndPosObj = GameObject.Find("EndPos");
        //rb = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(-speed, 0, 0);
        //rb.velocity = Vector2.left * ScrollSpeed;
        this.transform.Translate(Horizon, 0, 0);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "LaserEnd")
        {
            gameObject.SetActive(false);
        }
        
        if(col.gameObject.tag == "Shield")
        {
            gameObject.SetActive(false);
            EndPosObj.transform.position = this.transform.position;
        }
    }
}
