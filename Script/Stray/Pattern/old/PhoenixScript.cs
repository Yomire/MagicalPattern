using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class PhoenixScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public apPortrait PhoenixApPortrait;
    public float speed = 10;

    //今までいた位置を保持
    public Vector2 prev;

    public float Speed;
    public float Acceleration;
    public float RotationControl;
    float MovY, MovX = 1;
    public Transform Target;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }

    //初期化処理
    void Start()
    {
        player = GameObject.Find("PlayerObject");
    }

    void Update()
    {
        //MovY = Input.GetAxis("Vertical");

        if (player != null)
        {
            Vector2 Direction = transform.position - Target.position;

            //Direction.Normalize();

            //float cross = Vector3.Cross(Direction, transform.right).z;

            //rb.angularVelocity = cross * RotationControl;

            Vector2 Vel = transform.right * (MovX * Acceleration);
            rb.AddForce(Vel);

            float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

            Vector2 relForce = Vector2.up * thrustForce;

            rb.AddForce(rb.GetRelativeVector(relForce));

            if(rb.velocity.magnitude > Speed)
            {
                rb.velocity = rb.velocity.normalized * Speed;
            }

            //Move();
            if (rb.velocity.x > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = 1;
            }
            if (rb.velocity.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = -1;
            }

        }
    }

    //移動関数
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

    void OnTriggerEnter2D(Collider2D trcol)
    {
        /*if (trcol.gameObject.tag == "Attack")
        {
            ScreenShakeController.instance.StartShake(.2f, .1f);
            this.gameObject.SetActive(false);

            GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);

            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);
        }*/
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        /*if (col.gameObject.tag == "Attack")
        {
            this.gameObject.SetActive(false);
            ScreenShakeController.instance.StartShake(.2f, .1f);
            GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);

            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);
        }*/
    }
}
