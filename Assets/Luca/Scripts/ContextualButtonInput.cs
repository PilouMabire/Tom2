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

    private void OnEnable()
    {
        pressed = false;
        released = false;
        maintain = false;
    }

    private void Awake()
    {
        Instance = this;
        
    }

    

    

   IEnumerator OneFrameDelay()
    {
        yield return new WaitForFixedUpdate();
        released = false;
        pressed = false;
    }

    public void ButtonPressed()
    {
        //print("relaché");
        released = true;
        StartCoroutine(OneFrameDelay());
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        print("pressé");
        pressed = true;
        maintain = true;
        StartCoroutine(OneFrameDelay());
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
            StartCoroutine(OneFrameDelay());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            maintain = false;

        }
    }
    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
 