using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    bool radioOn;
    public AudioSource sound;

    public void ToogleRadio()
    {
        radioOn = !radioOn;
        if(radioOn)
        {
            sound.Play();
        }
        else
        {
            sound.Stop();
        }


    }
}
