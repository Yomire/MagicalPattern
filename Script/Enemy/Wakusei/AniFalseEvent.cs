using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniFalseEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void FalseMethod()
    {
        this.gameObject.SetActive(false);
    }
}
