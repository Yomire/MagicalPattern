using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    public float MoveUp, MoveDown, EndPosDown, EndPosUp;
    public string Flag;

    void FixedUpdate()
    {
        if (Flag == "Up")
        {
            this.transform.Translate(0, MoveUp, 0);
            if(this.transform.localPosition.y >= EndPosUp)
            {
                Flag = "Null";
            }
        }
        if (Flag == "Down")
        {
            this.transform.Translate(0, MoveDown, 0);
            if (this.transform.localPosition.y <= EndPosDown)
            {
                Flag = "Null";
            }
        }
    }
    public void UpMethod()
    {
        Flag = "Up";
    }
    public void DownMethod()
    {
        Flag = "Down";
    }
}
