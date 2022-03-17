using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSideControlScript : MonoBehaviour
{
    public Player script;

    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("test");
        if (collision.gameObject.tag == "DownFlick")
        {
            //Debug.Log("test");
            //Debug.Log("collider");
            if (script != null)
            {
                script.Slider();
            }
        }
        if (collision.gameObject.tag == "DownRight")
        {
            //Debug.Log("collider");
            if (script != null)
            {
                script.SliderRight();
            }
        }
        if (collision.gameObject.tag == "DownLeft")
        {
            //Debug.Log("collider");
            if (script != null)
            {
                script.SliderLeft();
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("test");
        if (collision.gameObject.tag == "DownFlick")
        {
            //Debug.Log("test");
            //Debug.Log("collider");
            if (script != null)
            {
                script.JoyColExitMethod();
            }
        }
        if (collision.gameObject.tag == "DownRight")
        {
            //Debug.Log("collider");
            if (script != null)
            {
                script.JoyColExitMethod();
            }
        }
        if (collision.gameObject.tag == "DownLeft")
        {
            //Debug.Log("collider");
            if (script != null)
            {
                script.JoyColExitMethod();
            }
        }
    }
}
