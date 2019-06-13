﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringObjectToFollow : MonoBehaviour
{
    Chien_Laisse chien;

    public GameObject objectToFollow;

   
    private void OnTriggerEnter(Collider other)
    {
        chien = other.GetComponent<Chien_Laisse>(); 
        if(chien)
        {
            chien.objectToFollow = objectToFollow;
            //chien.ChienSpeed = Random.Range(2f, 4f);
        }
    }
}
