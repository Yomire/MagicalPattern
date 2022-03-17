using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    //[SerializeField]
    //private Image fillImage;

    public Image SPGage, SPGageB;

    public ParticleSystem ChargePar;

    public AudioSource RecoveryAudio;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (SPGage.fillAmount != 0 && SPGageB.fillAmount != 0)
        {
            RecoveryAudio.Play();
            ChargePar.Play();
        }            
        pointerDown = true;
        //Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RecoveryAudio.Stop();
        ChargePar.Stop();
        Reset();
        //Debug.Log("OnPointerUp");
    }

    public void Update()
    {
        if(SPGage.fillAmount != 0 && SPGageB.fillAmount != 0)
        {
            if (pointerDown)
            {                
                pointerDownTimer += Time.deltaTime;
                if (pointerDownTimer >= requiredHoldTime)
                {
                    if (onLongClick != null)
                        onLongClick.Invoke();

                    pointerDownTimer = 0;
                    //Reset();
                }
                //SPGage.fillAmount -= 0.01f;
                //SPGageB.fillAmount -= 0.01f;
                //fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
            }
        }        
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        //fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }
}
