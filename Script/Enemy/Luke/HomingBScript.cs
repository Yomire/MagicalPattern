using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speed = 4, StartSpeed;
    public Vector2 prev;
    public TrailRenderer Trail;
    public AudioClip ColClip;
    public AudioSource SEASource;
    public ParticleSystem BulletPar;
    public string PauseFlag;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    private void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        rb.velocity = Vector2.right * StartSpeed;
        Trail.Clear();
    }

    void Start()
    {
        player = GameObject.Find("PlayerObject");
        //rb = GetComponent<Rigidbody2D>();
        prev = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if(PauseFlag == "Off")
            {
                Move();
            }     
            if(PauseFlag == "On")
            {
                rb.velocity = Vector3.zero;
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

        //本体の向きを調整
        Vector2 Position = transform.position;
        Vector2 diff = Position - prev;
        if (diff.magnitude > 0.01)
        {
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //次回角度計算のために現在位置を保持
        prev = Position;
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack" || trcol.gameObject.tag == "AttackSP" || trcol.gameObject.tag == "AttackSPB" || trcol.gameObject.tag == "Player" || trcol.gameObject.tag == "Shield")
        {
            ScreenShakeController.instance.StartShake(.2f, .1f);
            this.gameObject.SetActive(false);
            SEASource.clip = ColClip;
            SEASource.Play();
            GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);
            sm.AddScore(scoreValue);
            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);
        }
        if(trcol.gameObject.tag == "AnyPause")
        {
            BulletPar.playbackSpeed = 0;
            Trail.enabled = false;
            PauseFlag = "On";
            //Debug.Log("test");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB" || col.gameObject.tag == "Player" || col.gameObject.tag == "Shield")
        {
            SEASource.clip = ColClip;
            SEASource.Play();
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
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AnyPause")
        {
            BulletPar.playbackSpeed = 1;
            Trail.enabled = true;
            PauseFlag = "Off";
            //Debug.Log("test2");
        }
    }
}
