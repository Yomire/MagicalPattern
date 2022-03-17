using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript2 : MonoBehaviour
{
    public float ScrollSpeed = 7.0f;
    public float DestroyTime = 5.0f;
    public float Jump = 1.0f, DPosX, DPosY;
    public Rigidbody2D rb;
    public string flagMagnet = "Off";
    public GameObject CoinEffect, player, Trailobj;
    public Animator CoinAni;
    public Collider2D CoinCol;
    public TrailRenderer Trail;
    public Vector2 prev;
    public float speed = 4;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    private void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Trail.time = 0;
        Trailobj.SetActive(false);
        //rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        //Invoke("Disable", DestroyTime);
        //rb.velocity = new Vector2(SideJump, Jump);
        CoinEffect.SetActive(false);
        CoinCol.enabled = true;
        flagMagnet = "Off";
    }
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        //rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }

    void Update()
    {
        if (flagMagnet == "Off")
        {
            rb.velocity = Vector2.left * ScrollSpeed;
        }

        if (flagMagnet == "On")
        {
            Move();
            Trail.time = 1;
            Trailobj.SetActive(true);
        }
        if (this.transform.localPosition.y <= DPosY || this.transform.localPosition.x <= DPosX)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (this.gameObject != null)
            {
                flagMagnet = "Null";
                //rb.gravityScale = 0;
                rb.isKinematic = true;
                rb.velocity = new Vector2(0.0f, Jump);
                //Destroy(this.gameObject);
                CoinEffect.SetActive(true);
                CoinAni.Play("CoinGet", 0, 0.0f);
                Invoke("Disable", 0.5f);
                sm.AddScore(scoreValue);
                CoinCol.enabled = false;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Magnet")
        {
            flagMagnet = "On";
        }
    }
    void Disable()
    {
        this.gameObject.SetActive(false);
    }
    void Move()
    {
        //ユーザの場所を特定
        Vector2 Predetor = player.transform.position;

        float x = Predetor.x;
        float y = Predetor.y;
        //追跡方向の決定
        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        //ターゲット方向に力を加える
        rb.velocity = (direction * speed);
    }
}
