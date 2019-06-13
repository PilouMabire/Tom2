using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assise : MonoBehaviour
{

    public GameObject assise;
    public bool playerIsOn;

   

    // Update is called once per frame
    void Update()
    {
        if (playerIsOn)
        {
            Player3DExample.Instance.gameObject.transform.position = assise.transform.position;
            Player3DExample.Instance.gameObject.transform.rotation = assise.transform.rotation;

            if (Player3DExample.Instance.isMoving)
            {
                playerIsOn = false;
                Player3DExample.Instance.isSitted = false;
            }
        }





    }



    private void OnTriggerStay(Collider other)
    {
        if (!playerIsOn && Player3DExample.Instance.carrying == false)
        {
            UIManager.Instance.canInteract = true;
            if (ContextualButtonInput.Instance.pressed  )
            {
                playerIsOn = true;
                Player3DExample.Instance.isSitted = true;
            }
        }
    }
}
