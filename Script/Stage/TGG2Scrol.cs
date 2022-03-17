using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGG2Scrol : MonoBehaviour
{
    //public float speed = 1.0f;
    public float ScrollSpeed = 1.0f;
    //public float DisableTime = 5.0f;
    public Rigidbody2D rb;
    public GameObject LCObj;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    /*
    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.left * ScrollSpeed;
        }
        //Invoke("Disable", DisableTime);
    }
    */
    // Start is called before the first frame update
    /*
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, DestroyTime);
    }
    */
    // Update is called once per frame

    void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        LCObj = GameObject.Find("LevelControl");
    }
    void Update()
    {
        //transform.Translate(-speed, 0, 0);
        rb.velocity = Vector2.left * ScrollSpeed;
        if (this.transform.localPosition.x <= -15)
        {
            Invoke("DisableMethod", 0.01f);
            if (LCObj != null)
            {
                LevelGenerateScript.instance.DisableCountMethod();
            }                
        }
    }

    /*void Disable()
    {
        gameObject.SetActive(false);
    }*/
    /*
    private void OnDisable()
    {
        CancelInvoke();
    }
    */
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AttackSPB")
        {
            sm.AddScore(scoreValue);
            Invoke("DisableMethod", 0.01f);
            if (LCObj != null)
            {
                LevelGenerateScript.instance.DisableCountMethod();
            }
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
