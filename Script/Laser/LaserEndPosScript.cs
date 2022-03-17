using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEndPosScript : MonoBehaviour
{
    public string flag = "Go";
    public float Horizon = 1.0f;
    public float EndPos_X = 70;

    private void OnEnable()
    {
        this.transform.localPosition = Vector3.zero;
        //Invoke("Disable", DisableTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        flag = "Go";
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == "Go")
        {
            this.transform.Translate(Horizon, 0, 0);
        }
        else if (flag == "Stop")
        {
            this.transform.Translate(0, 0, 0);
        }

        if(this.transform.localPosition.x >= EndPos_X)
        {
            flag = "Stop";
        }
        else if (this.transform.localPosition.x <= EndPos_X)
        {
            flag = "Go";
            //Debug.Log(this.transform.position);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Shield")
        {
            flag = "Stop";
        }
    }

    /*void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Shield")
        {
            flag = "Go";
        }
    }*/
}
