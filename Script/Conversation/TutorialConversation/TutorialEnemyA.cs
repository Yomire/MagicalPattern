using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class TutorialEnemyA : MonoBehaviour
{
    //public apPortrait TerrorApPortrait;
    public DisableCounter CountScript;
    /*
    void Start()
    {
        TerrorApPortrait.Initialize();
        TerrorApPortrait.Play("Idle", 1);
    }
    */
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            if (CountScript != null)
            {
                CountScript.CountMethod();
            }

            GameObject obj12 = ObjectPooler12.current.GetPooledObject();
            if (obj12 == null) return;
            obj12.transform.position = this.transform.position;
            obj12.SetActive(true);

            GameObject obj13 = ObjectPooler13.current.GetPooledObject();
            if (obj13 == null) return;
            obj13.transform.position = this.transform.position;
            obj13.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}
