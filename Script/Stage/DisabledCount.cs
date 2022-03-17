using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledCount : MonoBehaviour
{
    public GameObject StageController;
    StageConScript SCS;

    private void OnEnable()
    {
        StageController = GameObject.Find("StageController");
        SCS = StageController.GetComponent<StageConScript>();
    }

    private void OnDisable()
    {
        SCS.CountMethod();
    }
}
