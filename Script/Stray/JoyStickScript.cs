﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image bgImage;
    private Image joystickImage;
    public float offset;

    public Vector2 InputDir { set; get; }

    // Start is called before the first frame update
    private void Start()
    {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        float bgImageSizeX = bgImage.rectTransform.sizeDelta.x;
        float bgImageSizeY = bgImage.rectTransform.sizeDelta.y;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x /= bgImageSizeX;
            pos.y /= bgImageSizeY;
            InputDir = new Vector2(pos.x, pos.y);
            InputDir = InputDir.magnitude > 1 ? InputDir.normalized : InputDir;

            joystickImage.rectTransform.anchoredPosition = new Vector2(InputDir.x * (bgImageSizeX/offset), InputDir.y * (bgImageSizeY/offset));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        InputDir = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;
    }
}
