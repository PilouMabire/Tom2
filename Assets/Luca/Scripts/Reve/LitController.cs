using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitController : MonoBehaviour
{

    public Joystick joystick;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Horizontal >0.3f)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LitRotateDroite"))
                anim.CrossFade("LitRotateDroite", 0.75f);
        }
        if (joystick.Horizontal < 0.3f)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LitRotateGauche"))
                anim.CrossFade("LitRotateGauche", 0.75f);
        }
    }
}
