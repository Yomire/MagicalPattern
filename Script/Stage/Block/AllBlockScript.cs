using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlockScript : MonoBehaviour
{
    public string Flag;
    public Rigidbody2D rb;
    public float ScrollSpeed;
    public int HPCount, MaxHP;
    public AudioClip DisableClip;
    public AudioSource SEASource;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        SEASource = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
    }
    public void BlockEnableMehod()
    {
        HPCount = MaxHP;
    }
    void Update()
    {
        if (Flag != "CoinFall")
        {
            rb.velocity = Vector2.left * ScrollSpeed;
        }            
        if(Flag == "CoinFall")
        {
            rb.velocity = Vector2.down * ScrollSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "JointRelease")
        {
            LevelGenerateScript.instance.DisableCountMethod();
            Invoke("DisableMethod", 0.01f);
        }
        if (trcol.gameObject.tag == "Attack")
        {
            if(Flag == "Brick")
            {
                LevelGenerateScript.instance.DisableCountMethod();
                ScreenShakeController.instance.StartShake(.1f, .05f);
                EffectMethod();
                Invoke("DisableMethod", 0.01f);
                sm.AddScore(scoreValue);
                SEASource.clip = DisableClip;
                SEASource.Play();
            }            
        }
        if (trcol.gameObject.tag == "AttackSP")
        {
            if (Flag == "Brick")
            {
                LevelGenerateScript.instance.DisableCountMethod();
                ScreenShakeController.instance.StartShake(.1f, .05f);
                EffectMethod();
                Invoke("DisableMethod", 0.01f);
                sm.AddScore(scoreValue);
                SEASource.clip = DisableClip;
                SEASource.Play();
            }
        }
        if (trcol.gameObject.tag == "Hammer")
        {
            if (Flag == "Hammer")
            {
                LevelGenerateScript.instance.DisableCountMethod();
                ScreenShakeController.instance.StartShake(.1f, .05f);
                EffectMethod();
                Invoke("DisableMethod", 0.01f);
                sm.AddScore(scoreValue);
                SEASource.clip = DisableClip;
                SEASource.Play();
            }
        }
        if (trcol.gameObject.tag == "AttackSPB")
        {
            LevelGenerateScript.instance.DisableCountMethod();
            ScreenShakeController.instance.StartShake(.1f, .05f);
            EffectMethod();
            Invoke("DisableMethod", 0.01f);
            SEASource.clip = DisableClip;
            sm.AddScore(scoreValue);
            SEASource.Play();
        }
        if (trcol.gameObject.tag == "CoinChange")
        {
            if(Flag == "Coin" || Flag == "CoinFall")
            {
                LevelGenerateScript.instance.DisableCountMethod();
                GameObject obj = ObjectPooler12.current.GetPooledObject();
                if (obj == null) return;
                obj.transform.position = this.transform.position;
                //obj.transform.rotation = ShotPosLeft.transform.rotation;
                obj.SetActive(true);
                Invoke("DisableMethod", 0.01f);
                ScreenShakeController.instance.StartShake(.1f, .05f);
                SEASource.clip = DisableClip;
                SEASource.Play();
            }            
        }
    }
    public void EffectMethod()
    {
        this.gameObject.SetActive(false);
        GameObject obj16 = ObjectPooler16.current.GetPooledObject();
        if (obj16 == null) return;
        obj16.SetActive(true);
        obj16.transform.position = this.transform.position;
    }
    public void DisableMethod()
    {        
        this.gameObject.SetActive(false);
    }
}
