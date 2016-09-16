using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualShootButton : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{

    private Image shootButtonBG;
    private Image shootButtonJoyStickImage;


    public Vector3 ShootInputDirection{ set; get; }

    void Start()
    {
        shootButtonBG = GetComponent<Image>();
        //I To get the child from the image inside the joystick background
        shootButtonJoyStickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        ShootInputDirection = Vector3.zero;

        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(shootButtonBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / shootButtonBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / shootButtonBG.rectTransform.sizeDelta.y);

            //I Still in progress to understand the code. Especially what is the question mark is for and stuff.
            float x = (shootButtonBG.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (shootButtonBG.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            ShootInputDirection = new Vector3(x,0,y);

            ShootInputDirection = (ShootInputDirection.magnitude > 1) ? ShootInputDirection.normalized : ShootInputDirection;

            //I This code is to avoid the middle circle to get out from the image joystick background. It will keep inside it.
            shootButtonJoyStickImage.rectTransform.anchoredPosition = new Vector3(ShootInputDirection.x * (shootButtonBG.rectTransform.sizeDelta.x / 3), ShootInputDirection.z * (shootButtonBG.rectTransform.sizeDelta.y/ 3));

            //IDebug.Log("OnDrag");
            //IDebug.Log(InputDirection);

        }
    }

    public virtual void  OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        ShootInputDirection = Vector3.zero;
        //I This is to reset the middle joystick button to reset to its original position instead of making it stick to the background and stuff.
        shootButtonJoyStickImage.rectTransform.anchoredPosition = Vector3.zero;
    }



}
