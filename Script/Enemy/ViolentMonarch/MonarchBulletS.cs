using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonarchBulletS : MonoBehaviour
{
    public float Size;
    public GameObject BulletPosObj;
    public Vector2 prev;
    public float speed = 0.01f, MoveX;
    public Rigidbody2D rb;
    public string Flag;
    public AudioSource SEASourceLoop;
    public AudioClip BulletSE;
    public void BulletEnable()
    {
        Size = 0.5f;
        transform.localScale = new Vector3(Size, Size, Size);
        Flag = "Charge";
        SEASourceLoop.clip = BulletSE;
        SEASourceLoop.Play();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Size += 0.03f;
            transform.localScale = new Vector3(Size, Size, Size);
        }
    }
    void Move()
    {
        //ユーザの場所を特定
        Vector2 Predetor = BulletPosObj.transform.position;

        float x = Predetor.x;
        float y = Predetor.y;
        //追跡方向の決定
        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        //ターゲット方向に力を加える
        rb.velocity = (direction * speed);
    }
    void Update()
    {        
        if(Flag == "Charge")
        {
            Move();
        }
        if(Flag == "Shot")
        {
            this.transform.Translate(MoveX, 0, 0);
        }
        if(this.transform.localPosition.y <= -15)
        {
            SEASourceLoop.Stop();
            this.gameObject.SetActive(false);
        }
    }
    public void ShotMethod()
    {
        Flag = "Shot";
    }
}
