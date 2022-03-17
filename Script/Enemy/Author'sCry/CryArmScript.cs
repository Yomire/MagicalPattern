using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryArmScript : MonoBehaviour
{
    public int HPCount, MaxHP;
    public Animator ani;
    public GameObject ParObj;
    public ParticleSystem DisablePar;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    public string EpisodeFlag;
    void OnEnable()
    {
        HPCount = MaxHP;
        if(EpisodeFlag != "Episode4")
        {
            sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }        
    }
    
    // Update is called once per frame
    public void Disable()
    {
        this.gameObject.SetActive(false);
        ParObj.transform.position = this.transform.position;
        //DisablePar.Play();

        GameObject obj14C = ObjectPooler14.current.GetPooledObject();
        if (obj14C == null) return;
        obj14C.transform.position = ParObj.transform.position;
        obj14C.SetActive(true);
    }

    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.2f, .1f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (col.gameObject.tag == "Attack")
            {
                HPMinusMethod();
                Shake();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                HPMinusMethodSP();
                Shake();
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (col.gameObject.tag == "Attack")
            {
                HPMinusMethod();
                Shake();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                HPMinusMethodSP();
                Shake();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (col.gameObject.tag == "Attack")
            {
                HPMinusMethod();
                Shake();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                HPMinusMethodSP();
                Shake();
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (col.gameObject.tag == "Attack")
            {
                HPMinusMethod();
                Shake();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                HPMinusMethodSP();
                Shake();
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            if (col.gameObject.tag == "Attack")
            {
                HPMinusMethod();
                Shake();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                HPMinusMethodSP();
                Shake();
            }
        }
        if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
        {
            if (col.gameObject.tag == "Attack")
            {
                HPMinusMethod();
                Shake();
            }
            if (col.gameObject.tag == "AttackSP" || col.gameObject.tag == "AttackSPB")
            {
                HPMinusMethodSP();
                Shake();
            }
        }
    }

    public void HPMinusMethod()
    {
        HPCount--;
        if (HPCount <= 0)
        {
            Disable();
            CoinMethodCentor();
            sm.AddScore(scoreValue);
        }
    }
    public void HPMinusMethodSP()
    {
        HPCount -= 2;
        if (HPCount <= 0)
        {
            Disable();
            CoinMethodCentor();
            sm.AddScore(scoreValue);
        }
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);
    }
}
