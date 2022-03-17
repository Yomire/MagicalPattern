using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public apPortrait BatApPortrait;
    public float speed = 4;
    public GameObject EffectPrefab;
    public GameObject Coin;

    //今までいた位置を保持
    public Vector2 prev;

    //初期化処理
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }

    void Update()
    {
        if (player != null)
        {
            Move();
            if (rb.velocity.x > 0)
            {
                BatApPortrait.Play("BatIdleRight", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
            }
            if (rb.velocity.x < 0) 
            {
                BatApPortrait.Play("BatIdleLeft", 1, apAnimPlayUnit.BLEND_METHOD.Interpolation, apAnimPlayManager.PLAY_OPTION.StopSameLayer, true);
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

        /*//本体の向きを調整
        Vector2 Position = transform.position;
        Vector2 diff = Position - prev;
        if (diff.magnitude > 0.01)
        {
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //次回角度計算のために現在位置を保持
        prev = Position;*/
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
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
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
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
        }
    }
}
