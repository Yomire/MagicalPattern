using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGHScript : MonoBehaviour
{
    public GameObject MoveGear1, MoveGear2, GearPosObj1, GearPosObj2;
    public float Horizon, EndPos_X1, EndPos_X2;
    public string Flag;
    public GearEnemy GCS1, GCS2;
    public int AttackNumber;
    public Animator HugeAni;
    public AudioSource SEASoursLoop;
    // Start is called before the first frame update
    public void OEMethod()
    {
        //Debug.Log("test");
        HugeAni.SetBool("CloseAniBool", false);
        HugeAni.SetBool("PurgeAniBool", false);
        Flag = "Null";
        MoveGear1.SetActive(true);
        MoveGear2.SetActive(true);
        GCS1.OEMethod();
        GCS2.OEMethod();
        Horizon = 0;
        /*GearPosObj1.transform.Translate(0, 20, 0);
        GearPosObj2.transform.Translate(0, 20, 0);*/
    }
    void Update()
    {
        if (Flag == "Move")
        {
            this.transform.Translate(Horizon, 0, 0, Space.World);
        }
        if (this.transform.localPosition.x <= EndPos_X1 || this.transform.localPosition.x >= EndPos_X2)
        {
            Flag = "Up";
            PurgeAniMethod();
        }
        if (Flag == "Up")
        {
            this.transform.Translate(0, 0.1f, 0, Space.World);
        }
    }
    public void MoveMethodLeft()
    {
        Flag = "Move";
        Horizon = -0.1f;
    }
    public void MoveMethodRight()
    {
        Flag = "Move";
        Horizon = 0.1f;
    }
    void OnTriggerEnter2D(Collider2D trcol)
    {
        if (trcol.gameObject.tag == "MoveSwitch")
        {
            SEASoursLoop.Play();
            AttackNumber = Random.Range(1, 3);
            if (AttackNumber == 1)
            {
                Invoke("MoveMethodRight", Random.Range(5, 10));
            }
            if (AttackNumber == 2)
            {
                Invoke("MoveMethodLeft", Random.Range(5, 10));
            }
        }
        if (trcol.gameObject.tag == "HugeFalse")
        {
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D trcol)
    {
        SEASoursLoop.Stop();
    }
    public void CloseAniMethod()
    {
        HugeAni.SetBool("CloseAniBool", true);
    }
    public void PurgeAniMethod()
    {
        HugeAni.SetBool("PurgeAniBool", true);
    }
}
