using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    Vector2 joystickCenter = Vector2.zero;

    void Start()
    {
        //le joystick commence invisible
        background.gameObject.SetActive(false);
    }

    public override void OnDrag(PointerEventData eventData) //lorsque le pointeur drag
    {

            //Direction est egal à la différence entre la position du doigt par rapport au centre du joystick
        Vector2 direction = eventData.position - joystickCenter;
        //Si la magnitude est supérieur à la taille du cercle de fond, la direction est égale au maximum, sinon, elle est égale à la force donnée.
        inputVector = (direction.magnitude > background.sizeDelta.x / 2.5f) ? direction.normalized : direction / (background.sizeDelta.x / 2.5f);
        //feedback visuel du joystick
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
        //tp le joystick
        //if(direction.magnitude > background.sizeDelta.x / 3.5)
        //{
        //    background.position = Vector3.Lerp(background.position,  eventData.position - direction.normalized/2, Time.deltaTime);

        //}
    }

    public override void OnPointerDown(PointerEventData eventData) //lorsque le pointeur appuye sur la zone limite
    {
        background.gameObject.SetActive(true); //le joystick devient visible
        background.position = eventData.position; //le joystick va sur la position du pointeur
        handle.anchoredPosition = Vector2.zero; //le joystick commence la ou le background est
        joystickCenter = eventData.position; 
    }

    public override void OnPointerUp(PointerEventData eventData) //quand on relache, le joystcik redevient invisible
    {
        background.gameObject.SetActive(false); 
        inputVector = Vector2.zero;
    }
}