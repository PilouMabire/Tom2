using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    bool radioOn;
    public AudioSource sound;

    public GameObject fx;

    public void ToogleRadio()
    {
        radioOn = !radioOn;
        if(radioOn)
        {
            sound.Play();
            fx.SetActive(true);
        }
        else
        {
            sound.Stop();
            fx.SetActive(false);
        }


    }

   
}
