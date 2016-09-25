using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualShootButton : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{

    private Image shootButtonBG;
    private Image shootButtonJoyStickImage;

    public float sensitivity;

    public Vector3 ShootInputDirection{ set; get; }

    void Start()
    {
        shootButtonBG = GetComponent<Image>();
        //I To get the child from the image inside the joystick background
        shootButtonJoyStickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(shootButtonBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            //I To make the inner joystick to rotate inside the BG only.
            pos.x = sensitivity*(pos.x / shootButtonBG.rectTransform.sizeDelta.x);
            pos.y = sensitivity*(pos.y / shootButtonBG.rectTransform.sizeDelta.y);


            ShootInputDirection = new Vector3(pos.x,0,pos.y);


            ShootInputDirection = (ShootInputDirection.magnitude > 1) ? ShootInputDirection.normalized : ShootInputDirection;


            //I This code is to avoid the middle circle to get out from the image joystick background. It will keep inside it.
            shootButtonJoyStickImage.rectTransform.anchoredPosition = new Vector3(ShootInputDirection.x * (shootButtonBG.rectTransform.sizeDelta.x / 3), ShootInputDirection.z * (shootButtonBG.rectTransform.sizeDelta.y/ 3));

            //IDebug.Log("OnDrag");
            //IDebug.Log(InputDirection);


        }
        /*if (ShootInputDirection.magnitude > 0.6f)
        {
            Debug.Log("Shoot Input Magnitude: " + ShootInputDirection.magnitude);

        }*/

        //Debug.Log("POS " + pos);
        //Debug.Log("POS X : " + pos.x);
        //Debug.Log("POS Y : " + pos.y);
    }

    public virtual void  OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
       
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        //I This is to reset the middle joystick button to reset to its original position instead of making it stick to the background
        ShootInputDirection = Vector3.zero;
        shootButtonJoyStickImage.rectTransform.anchoredPosition = Vector3.zero;
    }



}
