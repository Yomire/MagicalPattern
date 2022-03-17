using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCountPlus : MonoBehaviour
{
    public DisableCounter Counter;
    
    void OnDisable()
    {
        Counter.CountMethod();
    }
}
