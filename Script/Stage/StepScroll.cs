using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScroll : MonoBehaviour
{
    public float ScrollSpeed = 1.0f;
    //public float DisableTime = 5.0f;
    public string flag = "Scroll";

    private void OnEnable()
    {
        //Invoke("Disable", DisableTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "Scroll")
        {
            this.transform.Translate(ScrollSpeed, 0, 0);
        }
        if (flag == "Stop")
        {
            this.transform.Translate(0, 0, 0);
        }
        if (this.transform.localPosition.x <= 0)
        {
            //Debug.Log("test");
            flag = "Stop";
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
