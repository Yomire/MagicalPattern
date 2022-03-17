using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LockBombScript : MonoBehaviour
{
    public static LockBombScript instance;
    public float ScrollSpeed, DPosX;
    public Rigidbody2D rb;
    public SpriteRenderer Sprite1, Sprite2, Sprite3, Sprite4, Sprite5;
    public PlayableDirector LBTL;
    public string Flag;
    void OnEnable()
    {
        if(Flag == "RendTrue")
        {
            Sprite1.enabled = true;
            Sprite2.enabled = true;
            Sprite3.enabled = true;
            Sprite4.enabled = true;
            Sprite5.enabled = true;
        }
    }

    void Start()
    {
        instance = this;
    }
    
    public void LBTLPlayMethod()
    {
        LBTL.Play();
        Flag = "RendFalse";
    }
    public void RendTrueMethod()
    {
        Flag = "RendTrue";
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * ScrollSpeed;
        if (this.transform.localPosition.x <= DPosX)
        {
            LevelGenerateScript.instance.DisableCountMethod();
            Invoke("DisableMethod", 0.01f);
        }
    }

    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "AttackSPB" || trcol.gameObject.tag == "LockBombOn")
        {
            LBTL.Play();
            LevelGenerateScript.instance.DisableCountMethod();
        }
    }
}
