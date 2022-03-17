using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GsHScript : MonoBehaviour
{
    public GameObject MoveGear1, MoveGear2, MoveGear3, MoveGear4, MoveGear5, MoveGear6, MoveGear7, MoveGear8, 
        GearPosObj1, GearPosObj2, GearPosObj3, GearPosObj4, GearPosObj5, GearPosObj6, GearPosObj7, GearPosObj8;
    public float Horizon;
    public string Flag;
    public GearColScript GCS1, GCS2, GCS3, GCS4, GCS5, GCS6, GCS7, GCS8;
    public int AttackNumber;
    // Start is called before the first frame update
    public void OEMethod()
    {
        Flag = "Null";
        MoveGear1.SetActive(true);
        MoveGear2.SetActive(true);
        MoveGear3.SetActive(true);
        MoveGear4.SetActive(true);
        MoveGear5.SetActive(true);
        MoveGear6.SetActive(true);
        MoveGear7.SetActive(true);
        MoveGear8.SetActive(true);
        GCS1.HPReset();
        GCS2.HPReset();
        GCS3.HPReset();
        GCS4.HPReset();
        GCS5.HPReset();
        GCS6.HPReset();
        GCS7.HPReset();
        GCS8.HPReset();
        Horizon = 0;
        GearPosObj1.transform.Translate(0, 20, 0);
        GearPosObj2.transform.Translate(0, 20, 0);
        GearPosObj3.transform.Translate(0, 20, 0);
        GearPosObj4.transform.Translate(0, 20, 0);
        GearPosObj5.transform.Translate(0, 20, 0);
        GearPosObj6.transform.Translate(0, 20, 0);
        GearPosObj7.transform.Translate(0, 20, 0);
        GearPosObj8.transform.Translate(0, 20, 0);
    }
    void Update()
    {
        if (Flag == "Move")
        {
            this.transform.Translate(Horizon, 0, 0, Space.World);
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
        if (trcol.gameObject.tag == "EnemyFalse")
        {
            this.gameObject.SetActive(false);
        }
        if (trcol.gameObject.tag == "MoveSwitch")
        {
            AttackNumber = Random.Range(1, 3);
            if(AttackNumber == 1)
            {
                Invoke("MoveMethodRight", Random.Range(5, 10));
            }
            if (AttackNumber == 2)
            {
                Invoke("MoveMethodLeft", Random.Range(5, 10));
            }
        }
    }
}
