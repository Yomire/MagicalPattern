using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonaEpisode4 : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani.SetBool("SitDown2Bool", false);
    }

    public void SitEyeUpMethod()
    {
        ani.SetBool("SitDown2Bool", true);
    }
}
