using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectMoveTouch : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{

    private Image touchArea;
    public Image shootButtonJoystick;

    void Start()
    {
        shootButtonJoystick = GetComponent<Image>();


    }

    public virtual void OnDrag(PointerEventData ped)
    {

    }
	
    public virtual void  OnPointerDown(PointerEventData ped)
    {

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
