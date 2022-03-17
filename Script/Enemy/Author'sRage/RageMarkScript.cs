using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageMarkScript : MonoBehaviour
{
    public ParticleSystem ThunderEffectCentor, ThunderAttackLeftA, ThunderAttackLeftB, ThunderAttackRightA, ThunderAttackRightB, ThunderAttackUpA, ThunderAttackUpB, ThunderAttackDownA, ThunderAttackDownB;
    public GameObject DangerPos;
    public Collider2D CentorCollider, MarkColLeft, MarkColRight, MarkColUp, MarkColDown;
    public ARageScriptVer2 ARS;
    public AudioClip MarkClip, ThunderClip;
    public AudioSource SEASource, SEASourceLoop;

    void OnEnable()
    {
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        transform.eulerAngles = euler;
        //transform.rotation.z = Random.rotation;
        DangerA();
        DangerB();
        CentorCollider.enabled = false;
        MarkColLeft.enabled = false;
        MarkColRight.enabled = false;
        MarkColUp.enabled = false;
        MarkColDown.enabled = false;
    }

    public void DangerA()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = this.gameObject.transform.position;
        obj.transform.rotation = this.gameObject.transform.rotation;
        obj.SetActive(true);
    }

    public void DangerB()
    {
        GameObject obj = ObjectPooler5.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = DangerPos.transform.position;
        obj.transform.rotation = DangerPos.transform.rotation;
        obj.SetActive(true);
    }
    public void ParticlePlayCentor()
    {
        ThunderEffectCentor.Play();
    }
    public void ParticlePlay()
    {
        //ThunderEffectCentor.Play();
        ThunderAttackLeftA.Play();
        ThunderAttackRightA.Play();
        ThunderAttackUpA.Play();
        ThunderAttackDownA.Play();
        CentorCollider.enabled = true;
        MarkColLeft.enabled = true;
        MarkColRight.enabled = true;
        MarkColUp.enabled = true;
        MarkColDown.enabled = true;
        SEASourceLoop.clip = ThunderClip;
        SEASourceLoop.Play();
    }
    public void ParticleStop()
    {
        ThunderEffectCentor.Stop();
        ThunderAttackLeftA.Stop();
        ThunderAttackRightA.Stop();
        ThunderAttackUpA.Stop();
        ThunderAttackDownA.Stop();        
    }
    public void ColFalse()
    {
        CentorCollider.enabled = false;
        MarkColLeft.enabled = false;
        MarkColRight.enabled = false;
        MarkColUp.enabled = false;
        MarkColDown.enabled = false;
    }
    public void Shake()
    {
        ScreenShakeController.instance.StartShake(.3f, .2f);
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
        ARS.AniReset();
    }
    public void SEMethod()
    {
        SEASource.clip = MarkClip;
        SEASource.Play();
    }
    public void SEStopMethod()
    {
        SEASourceLoop.Stop();
    }
}
