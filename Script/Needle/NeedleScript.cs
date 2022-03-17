using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{
    public float Verticle = 1.0f;
    //private Vector3 StartRelativePosition;
    //public Transform FirstPos;
    public string flag = "Stop";
    public float EndPos_Y = 0.5f, GoDelay = 1.0f, DisableDelay = 3.0f;
    //public ShakeableTransform m_shakeable;
    public Animator Blackani, Blackani2;

    private void OnEnable()
    {
        flag = "Stop";
        this.transform.localPosition = Vector3.zero;
        Invoke("GoMethod", GoDelay);
        Invoke("Disable", DisableDelay);
    }

    // Start is called before the first frame update
    void Start()
    {
        Blackani = GameObject.Find("Crack").GetComponent<Animator>();
        Blackani2 = GameObject.Find("Crack (1)").GetComponent<Animator>();
        //m_shakeable = GameObject.Find("MainCamera").GetComponent<ShakeableTransform>();
        //StartRelativePosition = FirstPos.InverseTransformPoint(this.transform.localPosition);
        //FirstPos = this.transform.localPosition;
        //flag = "Go";
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == "Go")
        {
            this.transform.Translate(0, Verticle, 0);
            /*if (flag == "Go")
            {
                this.transform.Translate(0, Verticle, 0);
            }
            else if (flag == "Stop")
            {
                this.transform.Translate(0, 0, 0);
            }*/

            if (this.transform.localPosition.y >= EndPos_Y)
            {
                this.transform.localPosition = Vector3.zero;
                //flag = "Stop";
            }
            /*else if (this.transform.localPosition.y <= EndPos_Y)
            {
                flag = "Go";
                //Debug.Log(this.transform.position);
            }*/
        }

        else if (flag == "Stop")
        {
            this.transform.Translate(0, 0, 0);
        }
    }

    void GoMethod()
    {
        flag = "Go";
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Shield" || col.gameObject.tag == "Health-1")
        {
            //Debug.Log("test");
            //Vector3 ResetLocalPosition = FirstPos.TransformPoint(StartRelativePosition);
            //this.transform.localPosition = ResetLocalPosition;
            //flag = "Stop";
            this.transform.localPosition = Vector3.zero;
            //m_shakeable.InduceStress(1);
        }
        /*if (col.gameObject.tag == "Player")
        {
            //Debug.Log("test");
            flag = "Stop";
        }*/
        if (col.gameObject.tag == "Shield")
        {
            ScreenShakeController.instance.StartShake(.2f, .1f);
            //m_shakeable.InduceStress(1);
            Blackani.Play("Crack", 0, 0.0f);
            Blackani2.Play("Crack", 0, 0.0f);
        }
    }

    void Disable()
    {
        Blackani.Play("Crack Purge", 0, 0.0f);
        Blackani2.Play("Crack Purge", 0, 0.0f);
        this.gameObject.transform.root.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
