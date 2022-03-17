using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKickScript : MonoBehaviour
{
    public string Flag, PauseFlag;
    public float MoveX, EndPosY, ScrollSpeed, EndPosX;
    public Rigidbody2D rb;
    public Collider2D G2Col;
    public ParticleSystem RushPar;
    public GameObject CrackPos, CrackObj;
    public LukeScript LS;
    public AudioClip KickClip, JetClip;
    public AudioSource SEASource, SEASourceLoop;

    // Start is called before the first frame update
    void OnEnable()
    {
        if(PauseFlag == "Off")
        {
            Flag = "Move";
            RushPar.Play();
            PauseFlag = "On";
            SEASourceLoop.clip = JetClip;
            SEASourceLoop.Play();
            SEASourceLoop.volume = 1;
            SEASourceLoop.pitch = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Flag == "Move")
        {
            this.transform.Translate(MoveX, 0, 0);
            G2Col.enabled = true;
        }        
        if (this.transform.localPosition.y <= EndPosY)
        {
            if(Flag == "Move")
            {
                Flag = "Scroll";
                G2Col.enabled = false;
                RushPar.Stop();
                ScreenShakeController.instance.StartShake(.3f, .6f);
                SEASourceLoop.Stop();
                SEASourceLoop.volume = 0.2f;                
                SEASourceLoop.pitch = 1;
                Vector3 CPos = CrackPos.transform.position;
                CrackObj.transform.position = new Vector2(CPos.x, -3);
                CrackObj.SetActive(true);
                SEASource.clip = KickClip;
                SEASource.Play();
            }            
        }
        if(Flag == "Scroll")
        {
            rb.velocity = Vector2.left * ScrollSpeed;
        }
        if (this.transform.localPosition.x <= EndPosX)
        {
            if(Flag == "Scroll")
            {
                PauseFlag = "Off";
                LS.LIdleMethod();
                Invoke("DisableMethod", 0.01f);
            }
        }
    }
    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
