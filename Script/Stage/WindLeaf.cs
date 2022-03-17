using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLeaf : MonoBehaviour
{
    public float GScale, DPosX, DPosY;
    public Rigidbody2D rb;
    public TrailRenderer Trail;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    public void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (this.transform.localPosition.x >= 10)
        {
            Trail.time = 0;
            //Invoke("TrailTrueMethod", 0.01f);
        }
    }
    
    void Update()
    {
        if (this.transform.localPosition.y <= DPosY || this.transform.localPosition.x <= DPosX)
        {
            this.gameObject.SetActive(false);
        }
        Trail.time = 1;
    }
    void OnTriggerStay2D(Collider2D trcol)
    {
        /*
        if (trcol.gameObject.tag == "Player")
        {
            this.transform.parent = trcol.transform;
            //rb.isKinematic = true;
            Trail.time = 0;
            rb.gravityScale = 0;
        }
        */
        if (trcol.gameObject.tag == "Cut")
        {
            rb.gravityScale = GScale;
            //rb.bodyType = RigidbodyType2D.Dynamic;
            Trail.time = 0;
            this.transform.parent = null;
            Invoke("DisableMethod", 0.01f);
            sm.AddScore(scoreValue);
            LevelGenerateScript.instance.DisableCountMethod();
            GameObject obj16 = ObjectPooler16.current.GetPooledObject();
            if (obj16 == null) return;
            obj16.SetActive(true);
            obj16.transform.position = this.transform.position;
            //rb.gravityScale = GScale;
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Cut")
        {
            rb.gravityScale = GScale;
            //rb.bodyType = RigidbodyType2D.Dynamic;
            Trail.time = 0;
            this.transform.parent = null;
            Invoke("DisableMethod", 0.01f);
            sm.AddScore(scoreValue);
            LevelGenerateScript.instance.DisableCountMethod();
            GameObject obj16 = ObjectPooler16.current.GetPooledObject();
            if (obj16 == null) return;
            obj16.SetActive(true);
            obj16.transform.position = this.transform.position;
            //rb.gravityScale = GScale;
        }
    }
    /*
    void OnTriggerExit2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Player")
        {
            if(this.transform.parent != null)
            {
                this.transform.parent = null;
            }            
            //rb.isKinematic = true;
            //Trail.time = 0;
            rb.gravityScale = GScale;
        }
    }
    */
    public void DisableMethod()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }            
    }
    public void TrailTrueMethod()
    {
        Trail.time = 0;
    }
}
