using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFeedScript : MonoBehaviour
{
    public string flag = "Start";
    public GameObject StartObj;
    public float StartDelay = 0.0f, StageStartDelay = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartFlagMethod", StartDelay);
        Invoke("StartMethod", StageStartDelay);
    }
    public void StartMethod()
    {
        StartObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "Start")
        {
            if(this.transform.localPosition.x >= -850)
            {
                transform.Translate(-20f, 0f, 0f);
            }
        }
        if(flag == "Complete")
        {
            if (this.transform.localPosition.x <= 0)
            {
                transform.Translate(40f, 0f, 0f);
            }
            if (this.transform.localPosition.x >= 0)
            {
                SceneMethod();
            }
        }
        if(flag == "Stop")
        {
            transform.Translate(0f, 0f, 0f);
        }
    }
    public void StartFlagMethod()
    {
        flag = "Start";
    }
    public void Completeflag()
    {
        flag = "Complete";
    }
    public void SceneMethod()
    {
        flag = "Stop";
    }
}
