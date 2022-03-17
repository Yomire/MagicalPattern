using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public Vector2 prev;
    public float speed;
    public AudioClip DisableClip;
    public AudioSource SEASource;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        player = GameObject.Find("PlayerObject");
        prev = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Move();
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            }
            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
            }
        }        
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
        if (trcol.gameObject.tag == "Attack" || trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
            LevelGenerateScript.instance.DisableCountMethod();
            ScreenShakeController.instance.StartShake(.2f, .1f);
            this.gameObject.SetActive(false);
            SEASource.clip = DisableClip;
            SEASource.Play();
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
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
            this.gameObject.SetActive(false);
            ScreenShakeController.instance.StartShake(.2f, .1f);
            GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);
            SEASource.clip = DisableClip;
            SEASource.Play();
            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);
        }
    }
}
