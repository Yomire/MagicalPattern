using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBirthScript : MonoBehaviour
{
    private Animator ani;

    // Start is called before the first frame update
    void OnEnable()
    {
        ani = GetComponent<Animator>();
        ani.Play("BombDisableAni", 0, 0.0f);
    }
}
