using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;






public class VirtualJoystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private Image joystickBG;
    private Image joystickImage;

    public Vector3 InputDirection{ set; get; }

    void Start()
    {
        joystickBG = GetComponent<Image>();
        //I To get the child from the image inside the joystick background
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        InputDirection = Vector3.zero;

        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = 2f*(pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = 2f*(pos.y / joystickBG.rectTransform.sizeDelta.y);

            //I Still in progress to understand the code. Especially what is the question mark is for and stuff.
            float x = (joystickBG.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (joystickBG.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x,0,y);

            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            //I This code is to avoid the middle circle to get out from the image joystick background. It will keep inside it.
            joystickImage.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (joystickBG.rectTransform.sizeDelta.x / 3), InputDirection.z * (joystickBG.rectTransform.sizeDelta.y/ 3));



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
        InputDirection = Vector3.zero;
        //I This is to reset the middle joystick button to reset to its original position instead of making it stick to the background and stuff.
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }
}
