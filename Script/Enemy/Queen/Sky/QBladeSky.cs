using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBladeSky : MonoBehaviour
{
    public GameObject QBSkyFParObj, FParPosObj;
    public ParticleSystem FallBladeFPar;
    public float StartPosX, StartPosY;
    public string Flag, PauseFlag;
    public AudioClip EnableClip, ColClip, FeatherClip;
    public AudioSource SEASource, SEASource2;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if(PauseFlag == "Off")
        {
            QBSkyFParObj.transform.position = FParPosObj.transform.position;
            Vector3 FBPP = this.transform.eulerAngles;
            QBSkyFParObj.transform.eulerAngles = new Vector3(0, 0, -FBPP.z);
            PauseFlag = "On";
            SEASource.clip = EnableClip;
            SEASource.Play();
            FallBladeFPar.Play();
            SEASource2.clip = FeatherClip;
            SEASource2.Play();
        }        
    }

    void FixedUpdate()
    {
        this.transform.Translate(0, 0.3f, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Health-1")
        {
            ScreenShakeController.instance.StartShake(.1f, .2f);
            //Debug.Log("col");
            QBSkyFParObj.transform.position = FParPosObj.transform.position;
            Vector3 FBPP = FParPosObj.transform.eulerAngles;
            QBSkyFParObj.transform.eulerAngles = new Vector3(0, 0, FBPP.z);
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            Invoke("DisableBlade", 0.01f);
            SEASource.clip = ColClip;
            SEASource.Play();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Health-1")
        {
            ScreenShakeController.instance.StartShake(.1f, .2f);
            //Debug.Log("tri");
            QBSkyFParObj.transform.position = FParPosObj.transform.position;
            Vector3 FBPP = FParPosObj.transform.eulerAngles;
            QBSkyFParObj.transform.eulerAngles = new Vector3(0, 0, FBPP.z);
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            Invoke("DisableBlade", 0.01f);
            SEASource.clip = ColClip;
            SEASource.Play();
        }
    }
    public void DisableBlade()
    {
        PauseFlag = "Off";
        this.gameObject.SetActive(false);
    }
    public void CoinMethodCentor()
    {
        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = FParPosObj.transform.position;
        obj12.SetActive(true);
    }
    public void CoinMethodLeft()
    {
        GameObject obj = ObjectPooler41.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = FParPosObj.transform.position;
        obj.SetActive(true);
    }
    public void CoinMethodRight()
    {
        GameObject obj = ObjectPooler42.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = FParPosObj.transform.position;
        obj.SetActive(true);
    }
}
