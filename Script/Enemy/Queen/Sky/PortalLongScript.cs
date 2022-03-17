using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLongScript : MonoBehaviour
{
    public GameObject BladeObj1, BladeObj2, BladeObj3, BladeObj4, BladeObj5;
    public int AttackNumber;
    public Animator BPAnim;
    public string PauseFlag;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if(PauseFlag == "Off")
        {
            BPAnim.SetBool("BPSAni3Bool", false);
            PauseFlag = "On";
        }        
    }

    public void BladeEnableMethod()
    {
        AttackNumber++;
        if (AttackNumber == 1)
        {
            BladeObj1.SetActive(true);
        }
        if (AttackNumber == 2)
        {
            BladeObj2.SetActive(true);
        }
        if (AttackNumber == 3)
        {
            BladeObj3.SetActive(true);
        }
        if (AttackNumber == 4)
        {
            BladeObj4.SetActive(true);
        }
        if (AttackNumber == 5)
        {
            BladeObj5.SetActive(true);
            AttackNumber = 0;
        }
    }

    public void CloseMethod()
    {
        if (BladeObj1.activeSelf == false && BladeObj2.activeSelf == false && BladeObj3.activeSelf == false && BladeObj4.activeSelf == false && BladeObj5.activeSelf == false)
        {
            BPAnim.SetBool("BPSAni3Bool", true);
        }
    }

    public void DisableMethod()
    {
        PauseFlag = "Off";
        this.gameObject.SetActive(false);
    }
}
