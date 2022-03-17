using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPSetScript : MonoBehaviour
{
    public GameObject QueenBladeObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BladeDisableMethod()
    {
        QueenBladeObj.SetActive(false);
    }
    public void BladeEnableMethod()
    {
        QueenBladeObj.SetActive(true);
    }

    public void DisableMethod()
    {
        this.gameObject.SetActive(false);
    }
}
