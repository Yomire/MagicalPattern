using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class TerrorBoss : MonoBehaviour
{
    public apPortrait TerrorApPortrait;

    // Start is called before the first frame update
    void Start()
    {
        TerrorApPortrait.Initialize();
        TerrorApPortrait.Play("Idle", 1);
    }

    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            /*GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);
            */

            GameObject obj14 = ObjectPooler14.current.GetPooledObject();
            if (obj14 == null) return;
            obj14.transform.position = this.transform.position;
            obj14.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}
