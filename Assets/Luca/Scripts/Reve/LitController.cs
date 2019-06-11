using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitController : MonoBehaviour
{

    public Joystick joystick;
    public Vector3 localPos;

    public float joystickModifier;

    // Start is called before the first frame update
    void Start()
    {
        localPos = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        joystickModifier = Mathf.Lerp(joystickModifier, joystick.Horizontal, Time.deltaTime);
        //transform.localPosition =Vector3.Lerp(localPos,  localPos + new Vector3(joystick.Horizontal, 0 , 0), Time.deltaTime);
        //print(joystick.Horizontal);
        transform.localPosition =localPos + new Vector3(joystickModifier / 5, 0, 0);
    }
}
