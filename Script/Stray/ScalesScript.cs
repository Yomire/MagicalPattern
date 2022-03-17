using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesScript : MonoBehaviour
{
    public GameObject BloomPos1, BloomPos2, BloomPos3, BloomPos4;
    public int Count = 0;
    //public string CountFlag;
    // Start is called before the first frame update
    /*
    void OnEnable()
    {
        //Invoke("BloomDelayMethod", 3.0f);
        if(CountFlag == "Off")
        {
            CountFlag = "On";
            Count = 0;
        }
    }
    */
    /*void Update()
    {
        if(LightColor.a == 0)
        {
            LightColor.a += 0.1f;
        }
        if (LightColor.a == 1)
        {
            LightColor.a -= 0.1f;
        }
    }*/
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Ground")
        {
            BloomDelayMethod();
        }
        if (trcol.gameObject.tag == "Enemy")
        {
            BloomDelayMethod();
        }
        if (trcol.gameObject.tag == "Block")
        {
            BloomDelayMethod();
        }
        if (trcol.gameObject.tag == "Boss")
        {
            BloomDelayMethod();
        }
        if (trcol.gameObject.tag == "Ground2")
        {
            BloomDelayMethod();
        }
        if (trcol.gameObject.tag == "Health-1")
        {
            BloomDelayMethod();
        }
    }
    public void BloomMethod1()
    {
        GameObject obj = ObjectPooler35.current.GetPooledObject();
        if (obj == null) return;
        //obj.transform.parent = ArrowPos.gameObject.transform;
        obj.transform.position = BloomPos1.transform.position;
        //obj.transform.rotation = ArrowPos.transform.rotation;
        obj.SetActive(true);
    }
    public void BloomMethod2()
    {
        GameObject obj = ObjectPooler35.current.GetPooledObject();
        if (obj == null) return;
        //obj.transform.parent = ArrowPos.gameObject.transform;
        obj.transform.position = BloomPos2.transform.position;
        //obj.transform.rotation = ArrowPos.transform.rotation;
        obj.SetActive(true);
    }
    public void BloomMethod3()
    {
        GameObject obj = ObjectPooler35.current.GetPooledObject();
        if (obj == null) return;
        //obj.transform.parent = ArrowPos.gameObject.transform;
        obj.transform.position = BloomPos3.transform.position;
        //obj.transform.rotation = ArrowPos.transform.rotation;
        obj.SetActive(true);
    }
    public void BloomMethod4()
    {
        if(BloomPos4 != null)
        {
            GameObject obj = ObjectPooler35.current.GetPooledObject();
            if (obj == null) return;
            //obj.transform.parent = ArrowPos.gameObject.transform;
            obj.transform.position = BloomPos4.transform.position;
            //obj.transform.rotation = ArrowPos.transform.rotation;
            obj.SetActive(true);
        }        
    }
    public void BloomDelayMethod()
    {
        BloomMethod1();
        BloomMethod2();
        BloomMethod3();
        BloomMethod4();
        this.gameObject.SetActive(false);
        //CountFlag = "Off";
        Count = 0;
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    public void CountMethod()
    {
        Count++;
        if(Count == 4)
        {
            BloomDelayMethod();
        }
    }
}
