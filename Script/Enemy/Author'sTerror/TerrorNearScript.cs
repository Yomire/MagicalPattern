using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class TerrorNearScript : MonoBehaviour
{
    public apPortrait TerrorApPortrait;
    public float EndPos_X = -19, SpeedX, Low = 0.01f, High = 1f, nowPosi;
    public DisableCounter CountScript;
    // Start is called before the first frame update
    void OnEnable()
    {
        nowPosi = this.transform.position.y;
        SpeedX = Random.Range(Low, High);
    }

    // Update is called once per frame
    void Update()
    {
        TerrorApPortrait.Play("Idle", 1);
        if (this.transform.localPosition.x >= EndPos_X)
        {
            this.transform.Translate(-SpeedX, 0, 0);
            transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / -3, 1f), transform.position.z);
        }
        if (this.transform.localPosition.x <= EndPos_X)
        {
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "Attack")
        {
            if(CountScript != null)
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
        if (trcol.gameObject.tag == "Stop")
        {
            SpeedZero();
        }
    }

    public void SpeedZero()
    {
        SpeedX = 0;
    }
}
