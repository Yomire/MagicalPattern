using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailScript : MonoBehaviour
{
    public string flag = "Stop";
    public float SpeedY = 1.0f;
    public AudioClip RotateClip, DisableClip;
    public AudioSource SEASours;

    void OnEnable()
    {
        SEASours = GameObject.Find("SEAudioSource1").GetComponent<AudioSource>();
        flag = "Stop";
        Invoke("RotateMethod", 1.0f);
        Invoke("GoMethod", 3.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if(flag == "Go")
        {
            this.transform.Translate(0, SpeedY, 0);
        }
    }

    public void RotateMethod()
    {
        if(this.gameObject.activeSelf)
        {
            //Quaternion quaternion = this.transform.rotation;
            //float rot_z = quaternion.eulerAngles.z;

            //transform.Rotate(new Vector3(0, 0, Random.Range(240, 280)));
            SEASours.clip = RotateClip;
            SEASours.Play();
            Transform myTransform = this.transform;

            // ワールド座標を基準に、回転を取得
            Vector3 worldAngle = myTransform.eulerAngles;
            worldAngle.x = 0.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
            worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
            worldAngle.z = Random.Range(150, 220); // ワールド座標を基準に、z軸を軸にした回転を10度に変更
            myTransform.eulerAngles = worldAngle; // 回転角度を設定

            GameObject obj = ObjectPooler5.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);
        }        
    }
    public void GoMethod()
    {
        flag = "Go";
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            GameObject obj = ObjectPooler13.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);
            SEASours.clip = DisableClip;
            SEASours.Play();
            Invoke("Disable", 0.01f);
            ShakeMethod();
        }
        if (col.gameObject.tag == "Shield")
        {
            GameObject obj = ObjectPooler13.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);
            SEASours.clip = DisableClip;
            SEASours.Play();
            Invoke("Disable", 0.01f);
            ShakeMethod();
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Ground")
        {
            GameObject obj = ObjectPooler13.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);

            Invoke("Disable", 0.01f);
            ShakeMethod();
        }
        if (trcol.gameObject.tag == "Shield")
        {
            GameObject obj = ObjectPooler13.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.SetActive(true);

            Invoke("Disable", 0.01f);
            ShakeMethod();
        }
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
        GameObject obj = ObjectPooler12.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }
    public void ShakeMethod()
    {
        ScreenShakeController.instance.StartShake(.25f, .5f);
    }
}
