using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPSLongBlade : MonoBehaviour
{
    public string Flag;
    public float StartPosX, StartPosY;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Flag = "Enable";
    }

    void FixedUpdate()
    {
        this.transform.Translate(0, 0.3f, 0);
        if (this.transform.localPosition.y <= 8)
        {
            this.transform.position = new Vector3(StartPosX, StartPosY, 0);
            if(Flag == "Disable")
            {
                if (this.gameObject.activeSelf)
                {
                    this.gameObject.SetActive(false);
                }                
            }
        }
    }
    public void DisableFlagMethod()
    {
        Flag = "Disable";
    }
}
