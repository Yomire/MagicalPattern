using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLanceScript : MonoBehaviour
{
    public float StartPosX, StartPosY, EndPosY, EndPosUp, EndPosBottom, EndPosRight, EndPosLeft;
    public string Flag = "Fall", PauseFlag;
    public GameObject LDParEular;
    public AudioClip SEClip, EnableClip;
    public AudioSource SEASours;

    void OnEnable()
    {
        SEASours = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        if (PauseFlag == "Off")
        {
            PauseFlag = "On";
            Flag = "Fall";
            SEASours.clip = EnableClip;
            SEASours.Play();
        }        
    }

    void FixedUpdate()
    {
        if (Flag == "Fall")
        {
            this.transform.Translate(-0.3f, 0, 0);
        }
        /*
        if (this.transform.localPosition.y <= EndPosY)
        {
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            DisableParMethod();
            Flag = "Stop";
            ScreenShakeController.instance.StartShake(.1f, .2f);
            Invoke("FallBladePosReset", 0.01f);
        }
        */

        if (this.transform.localPosition.y >= EndPosUp)
        {
            DisableParMethod();
            FallBladePosReset();
        }
        if (this.transform.localPosition.y <= EndPosBottom)
        {
            DisableParMethod();
            FallBladePosReset();
        }
        if (this.transform.localPosition.x >= EndPosRight)
        {
            DisableParMethod();
            FallBladePosReset();
        }
        if (this.transform.localPosition.x <= EndPosLeft)
        {
            DisableParMethod();
            FallBladePosReset();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Health-1")
        {
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            DisableParMethod();
            Flag = "Stop";
            ScreenShakeController.instance.StartShake(.1f, .2f);
            Invoke("FallBladePosReset", 0.01f);
            PauseFlag = "Off";
        }
    }
    public void FallBladePosReset()
    {
        this.transform.position = new Vector2(StartPosX, StartPosY);
        this.gameObject.SetActive(false);
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);
    }
    public void CoinMethodLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void DisableParMethod()
    {
        GameObject obj = ObjectPooler44.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = this.transform.position;
        obj.transform.rotation = LDParEular.transform.rotation;
        obj.SetActive(true);

        SEASours.clip = SEClip;
        SEASours.Play();
    }
}
