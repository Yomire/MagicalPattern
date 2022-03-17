using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBackDisble : MonoBehaviour
{
    public GameObject Obj;
    private void OnParticleSystemStopped()
    {
        Obj.SetActive(false);
    }
}
