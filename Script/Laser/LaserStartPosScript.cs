using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStartPosScript : MonoBehaviour
{
    public string flag = "Stop";
    public float Horizon = 1.0f;
    public float GoDelay = 2.0f;
    public Collider2D StartCol;

    private void OnEnable()
    {
        StartCol.enabled = false;
        flag = "Stop";
        this.transform.localPosition = Vector3.zero;
        //Invoke("Disable", DisableTime);
        Invoke("GoMethod", GoDelay);
    }

    void Update()
    {
        if (flag == "Go")
        {
            this.transform.Translate(Horizon, 0, 0);
        }
        else if (flag == "Stop")
        {
            this.transform.Translate(0, 0, 0);
        }
    }

    void GoMethod()
    {
        flag = "Go";
        StartCol.enabled = true;
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "LaserEnd")
        {
            flag = "Stop";
            this.gameObject.transform.root.gameObject.SetActive(false);
        }
    }
}
