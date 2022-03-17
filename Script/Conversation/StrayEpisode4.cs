using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrayEpisode4 : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani.SetBool("SitBool", false);
    }

    public void SitMethod()
    {
        ani.SetBool("SitBool", true);
    }
}
