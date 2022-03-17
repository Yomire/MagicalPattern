using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockS : MonoBehaviour
{
    private Animator ani;
    public GameObject PlayerObj;
    Player Pscript;
    private string flag;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        PlayerObj = GameObject.Find("PlayerObject");
        if(PlayerObj != null)
        {
            Pscript = PlayerObj.GetComponent<Player>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObj != null)
        {
            flag = Pscript.flagLock;
        }

        if(flag == "Off")
        {
            ani.SetBool("Off", true);
            ani.SetBool("On", false);
            //ani.Play("Lock1", 0, 0.0f);
        }
        else if (flag == "On")
        {
            ani.SetBool("On", true);
            ani.SetBool("Off", false);
            //ani.Play("Lock2", 0, 0.0f);
        }
    }
}
