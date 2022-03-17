using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    private Image bgImage;
    private Image joystickImage;
    public float offset;
    public Vector2 InputDir { set; get; }

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    public GameObject PlayerObject;
    Player script;

    private void Start()
    {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector2.zero;

        script = GameObject.Find("PlayerObject").GetComponent<Player>();
    }

    /*void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StickCollider")
        {
            //Debug.Log("collider");
            if (script != null)
            {
                script.Slider();
            }
        }
    }*/

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
            //Debug.Log(InputDir);

            touchEndPos = new Vector2(InputDir.x, InputDir.y);
            //GetDirection();
            if(script != null)
            {
                GetDirection();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);

        touchStartPos = new Vector2(InputDir.x, InputDir.y);
        //GetDirection();
        if (script != null)
        {
            GetDirection();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDir = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;
        if (script != null)
        {
            script.DirectionNull();
            //script.FlagMethod();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        //string Direction;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (0.3 < directionX)
            {
                
                //Debug.Log("RightFlick");

                script.RightJump();
            }

            else if (-0.3 > directionX)
            {
                
                //Debug.Log("leftFlick");
                script.LeftJump();
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (0.1 < directionY)
            {
                
                //Debug.Log("upFlick");

                script.jumpButton();
            }

            else if (-0.1 > directionY)
            {
                
                //Debug.Log("down");
            }
        }

        else
        {
            
            //Debug.Log("touch");
        }
    }

}
