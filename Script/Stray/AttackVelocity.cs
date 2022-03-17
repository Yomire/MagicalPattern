using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVelocity : MonoBehaviour
{
    //public float speed = 1.0f;
    public float SpeedX = 1.0f;
    public float SpeedY = -2.0f;
    //public float DestroyTime = 5.0f;
    private Rigidbody2D rb;
    public string flagA = "velocityXY";
    public string flagB = "true";
    public int sortingOrderNew = 0;
    private Renderer myRenderer;

    private void OnEnable()
    {
        if(rb != null)
        {
            rb.velocity = new Vector2(SpeedX, SpeedY);
        }
        Invoke("Disable", 6f);
        flagA = "velocityXY";
        this.gameObject.transform.parent = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, DestroyTime);
        flagA = "velocityXY";
        flagB = "true";
    }
    
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flagA == "velocityXY")
        {
            //transform.Translate(-speed, 0, 0);
            rb.velocity = new Vector2(SpeedX, SpeedY);
        }
        if (flagA == "joint")
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(flagB == "true")
        {
            if (col.gameObject.tag == "Joint")
            {
                //Debug.Log("joint");
                flagA = "joint";
                this.transform.parent = col.transform;
                myRenderer.sortingOrder = (int)(sortingOrderNew);
                flagB = "false";
            }
        }

        if(col.gameObject.tag == "JointRelease")
        {
            this.transform.parent = null;
            //Debug.Log(this.transform.parent);
            flagA = "velocityXY";
            flagB = "true";
            gameObject.SetActive(false);
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
