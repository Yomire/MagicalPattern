using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class TScript : MonoBehaviour
{
    public apPortrait TerrorApPortrait;
    public string flag = "Go", flagHP = "false";
    public float SpeedX = 0.02f;
    public float EndPos_X = -17;
    public SpriteRenderer HP1Sprite;
    public GameObject HPHolder, CompleteObj, TextUI, GroundGeneObj;
    public BlackFeedScript BlackObj;
    bool isCalledOnce = false;
    public int HPCount = 0;
    public float High = 3f;
    public float Low = -3f;
    public float PosXHigh = 20f;
    public float PosXLow = 20f;
    public Collider2D Col1, Col2, Col3, Col4, Col5;
    //public Text TextUI;

    // Start is called before the first frame update
    void Start()
    {
        TextUI.SetActive(false);
        HPHolder.SetActive(false);
        //flagHP = "HP1Set";
        flag = "Stop";
        Invoke("flagGo", 50.0f);
        Col1.enabled = false;
        Col2.enabled = false;
        Col3.enabled = false;
        Col4.enabled = false;
        Col5.enabled = false;
    }
    public void flagGo()
    {
        Col1.enabled = true;
        Col2.enabled = true;
        Col3.enabled = true;
        Col4.enabled = true;
        Col5.enabled = true;
        TextUI.SetActive(true);
        HPHolder.SetActive(true);
        flag = "Go";
        flagHP = "HP1Set";
    }
    // Update is called once per frame
    void Update()
    {
        //AllDisablel.instance.DisableCall();
        TerrorApPortrait.Play("Idle", 1);
        if(flag == "Go")
        {
            this.transform.Translate(SpeedX, 0, 0);
        }
        if (flag == "Back")
        {
            if (this.transform.localPosition.x >= EndPos_X)
            {
                this.transform.Translate(-0.5f, 0, 0);
            }
        }

        if (flagHP == "Idle")
        {
            if (HPHolder != null)
            {
                if (HP1Sprite.size.x <= 1.28)
                {
                    //flagHP = "HP1Set";
                    HPCount++;
                }
            }
        }
        if (HPCount == 1)
        {
            //AllDisablel.instance.DisableCall();
            AllDisablel.DisableCount = 1;
            TextUI.SetActive(false);
            GroundGeneObj.SetActive(false);
            HPHolder.SetActive(false);
            Invoke("DestroyMethod", 0.1f);
            Invoke("FeedOutMethod", 1.0f);
            /*if (!isCalledOnce)
            {
               // isCalledOnce = true;
            }*/
        }
        if (flagHP == "HP1Set")
        {
            HP1Sprite.size += new Vector2(0.05f, 0.0f);
            if (HP1Sprite.size.x >= 11)
            {
                flagHP = "Idle";
            }
        }
    }
    public void DestroyMethod() 
    {
        this.gameObject.SetActive(false);
        DisableMethod();
        CompleteMethod();
    }
    public void BackMethod()
    {
        if (flag != "Stop")
        {
            flag = "Back";
            Invoke("GoMethod", 0.5f);
        }
    }
    public void GoMethod()
    {
        flag = "Go";
    }
    public void CompleteMethod()
    {
        CompleteObj.SetActive(true);
    }
    public void FeedOutMethod()
    {
        BlackObj.Completeflag();
    }
    public void DisableMethod()
    {
        GameObject obj = ObjectPooler14.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);

        Shake();
    }
    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }
    public void DamageMethod()
    {
        if(flag != "Stop")
        {
            if (flagHP == "Idle")
            {
                HP1Sprite.size -= new Vector2(0.05f, 0.0f);
                Shake();
            }
        }
    }
    public void Damage2Method()
    {
        if (flag != "Stop")
        {
            if (flagHP == "Idle")
            {
                HP1Sprite.size -= new Vector2(0.02f, 0.0f);
                ScreenShakeController.instance.StartShake(.1f, .05f);
            }
        }
    }
    void CreateFX()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        //obj.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
        obj.SetActive(true);
        //obj.transform.Rotate(0, 0, Random.Range(RotationLow, RotationHigh));
    }
}
