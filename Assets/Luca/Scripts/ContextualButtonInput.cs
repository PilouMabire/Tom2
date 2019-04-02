using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextualButtonInput : MonoBehaviour
     //,IPointerClickHandler
     //, IDragHandler
     //, IPointerEnterHandler
     , IPointerExitHandler
    , IPointerDownHandler
    , IPointerUpHandler
{
    public static ContextualButtonInput Instance;

    public bool pressed;
    public bool released;
    public bool maintain;

    private void Start()
    {
        Instance = this;
        
    }

   

    public void ButtonPressed()
    {
        //print("relaché");
        released = true;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //print("pressé");
        pressed = true;
        maintain = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        maintain = false;
        //print("relaché/outofbutton");
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        maintain = false;
        //Debug.Log(name + "No longer being clicked");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed = true;
            maintain = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            maintain = false;
            released = true;
        }
    }
    private void LateUpdate()
    {
        released = false;
        pressed = false;
    }
}
 