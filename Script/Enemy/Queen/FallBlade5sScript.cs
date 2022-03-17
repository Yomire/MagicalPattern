using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlade5sScript : MonoBehaviour
{
    public GameObject FallBladeFParObj;
    public ParticleSystem FallBladeFPar;
    public float StartPosX, StartPosY, EndPosY;
    public string Flag = "Fall";

    void OnEnable()
    {
        Flag = "Fall";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Flag == "Fall")
        {
            this.transform.Translate(0, 0.3f, 0);
        }            
        if (this.transform.localPosition.y <= EndPosY)
        {
            CoinMethodCentor();
            CoinMethodLeft();
            CoinMethodRight();
            Flag = "Stop";
            Vector3 FBPP = this.transform.position;
            FallBladeFParObj.transform.position = new Vector2(FBPP.x, -3.98f);
            FallBladeFPar.Play();
            ScreenShakeController.instance.StartShake(.1f, .2f);
            Invoke("FallBladePosReset", 0.01f);
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
}
