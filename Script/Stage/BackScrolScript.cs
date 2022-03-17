using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrolScript : MonoBehaviour
{
    public float MoveX, EndPosX = -21, StartPosX = 21, StartPosY = -4.5f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(MoveX, 0, 0);
        if (this.transform.localPosition.x <= EndPosX)
        {
            this.transform.localPosition = new Vector3(StartPosX, StartPosY, 0);
        }
    }
}
