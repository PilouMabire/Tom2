﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancoireManager : MonoBehaviour
{
    public GameObject fugueItem;
    public Animator anim;

    public bool soundAlreadyPlayed;
    public AudioSource sound;
 

    public void Fugue()
    {
        fugueItem.SetActive(true);
        anim.Play("fugue");
    }

    public void RetourMaison()
    {
        anim.Play("retourMaison");
        Player3DExample.Instance.canMove = false;
    }

    public void PlayRetour()
    {
        if(!soundAlreadyPlayed)
        {
            soundAlreadyPlayed = true;
            sound.Play();
        }
    }
}
