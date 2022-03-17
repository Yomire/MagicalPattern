using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDisablel : MonoBehaviour
{
    //public static AllDisablel instance;
    public static int DisableCount;
    // Start is called before the first frame update
    void OnEnable()
    {
        DisableCount = 0;
        //instance = this;
    }

    void Update()
    {
        if(DisableCount != 0)
        {
            DisableCall();
        }
    }

    // Update is called once per frame
    public void DisableCall()
    {
        //Debug.Log("test");
        GameObject obj = ObjectPooler13.current.GetPooledObject();
        if (obj == null) return;
        //obj.transform.rotation = this.gameObject.transform.rotation;
        obj.transform.position = this.gameObject.transform.position;
        obj.SetActive(true);

        GameObject obj12 = ObjectPooler12.current.GetPooledObject();
        if (obj12 == null) return;
        obj12.transform.position = this.transform.position;
        obj12.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
