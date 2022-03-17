using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMonarch : MonoBehaviour
{
    public float ScrollSpeed = 7.0f;
    //public float DestroyTime = 5.0f;
    public float Jump = 1.0f;
    private Rigidbody2D rb;
    public string flag = "Null";
    public GameObject CoinEffect, player, Trailobj, BulletObj;
    public Animator CoinAni;
    public Collider2D CoinCol;
    public Vector2 prev;
    public float speed = 4;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    private void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //Trailobj.SetActive(false);
        //flag = "Null";
        rb = GetComponent<Rigidbody2D>();
        CoinEffect.SetActive(false);
        CoinCol.enabled = true;
        if(flag != "Stray")
        {
            flag = "Bullet";
        }
    }
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        BulletObj = GameObject.Find("MonarchBulletPar");
        //rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }
    void Update()
    {
        Move();
        Trailobj.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Magnet")
        {
            //flagMagnet = "On";
            flag = "Stray";
        }
        if (trcol.gameObject.tag == "Ground2")
        {
            if (this.gameObject != null)
            {
                flag = "Null";
                //rb.gravityScale = 0;
                //rb.isKinematic = true;
                //rb.velocity = new Vector2(0.0f, Jump);
                //Destroy(this.gameObject);
                CoinEffect.SetActive(true);
                CoinAni.Play("CoinGet", 0, 0.0f);
                Invoke("Disable", 0.5f);
                CoinCol.enabled = false;
            }
        }
        if (trcol.gameObject.tag == "Player")
        {
            if (this.gameObject != null)
            {
                flag = "Null";
                //rb.gravityScale = 0;
                //rb.isKinematic = true;
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
    void Disable()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    void Move()
    {
        if(flag == "Bullet")
        {
            //ユーザの場所を特定
            Vector2 Predetor = BulletObj.transform.position;

            float x = Predetor.x;
            float y = Predetor.y;
            //追跡方向の決定
            Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
            //ターゲット方向に力を加える
            rb.velocity = (direction * speed);
        }  
        if(flag == "Stray")
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
}
