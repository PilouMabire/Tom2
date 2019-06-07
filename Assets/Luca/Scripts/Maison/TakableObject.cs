﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakableObject : MonoBehaviour
{
    public bool taken;
    public string objectID;

    public bool isMask;
    public GameObject mask;

<<<<<<< HEAD
    public AudioSource klaxonSound;
=======
    public bool isTakable = true;
>>>>>>> master

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if(isTakable)
        {
            if (collision.gameObject.GetComponent<Player3DExample>())
            {
                UIManager.Instance.canInteract = true;
            }
            if (ContextualButtonInput.Instance.maintain && Player3DExample.Instance.carrying == false)
            {
<<<<<<< HEAD
                if(!isMask)
                {
                    klaxonSound.Play();
                    Vibration.Vibrate(50);
                    taken = true;
                    transform.position = Player3DExample.Instance.forward.transform.position;
                    transform.SetParent(Player3DExample.Instance.transform);
                    Player3DExample.Instance.carrying = true;
                }
                else
=======
                if (collision.gameObject.GetComponent<Player3DExample>())
>>>>>>> master
                {
                    if (!isMask)
                    {
                        Vibration.Vibrate(50);
                        taken = true;
                        transform.position = Player3DExample.Instance.forward.transform.position;
                        transform.SetParent(Player3DExample.Instance.transform);
                        Player3DExample.Instance.carrying = true;
                    }
                    else
                    {
                        Vibration.Vibrate(50);
                        mask.SetActive(true);
                        Destroy(gameObject);
                    }

                }

            }
            if (taken)
            {
                if (collision.gameObject.GetComponent<ObjectTaker>())
                {
                    if (collision.gameObject.GetComponent<ObjectTaker>().objectID == objectID)
                    {
                        Vibration.Vibrate(100);
                        Player3DExample.Instance.carrying = false;
                        Destroy(gameObject);
                    }

                }
            }
        }
        
        
    }
}
