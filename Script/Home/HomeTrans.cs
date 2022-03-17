using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTrans : MonoBehaviour
{
    private Animator ani;

    public AudioSource SESource;
    public AudioClip SelectSound;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        
    }

    public void Trans0Method()
    {
        //int trans = ani.GetInteger("trans");
        ani.SetInteger("trans", 0);
        //Debug.Log("test0");
        SESource.PlayOneShot(SelectSound);
    }
    public void Trans1Method()
    {
        ani.SetInteger("trans", 1);
        //Debug.Log("test1");
        SESource.PlayOneShot(SelectSound);
    }
    public void Trans2Method()
    {
        ani.SetInteger("trans", 2);
        //Debug.Log("test2");
        SESource.PlayOneShot(SelectSound);
    }
    public void Trans3Method()
    {
        ani.SetInteger("trans", 3);
        //Debug.Log("test3");
        SESource.PlayOneShot(SelectSound);
    }
    public void Trans4Method()
    {
        ani.SetInteger("trans", 4);
        //Debug.Log("test4");
        SESource.PlayOneShot(SelectSound);
    }
}
