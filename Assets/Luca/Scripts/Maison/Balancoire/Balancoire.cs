using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancoire : MonoBehaviour
{

    public Animator anim;
    public GameObject assise;
    public bool playerIsOn;
    public bool hasDoneBalancoire;

   

    // Update is called once per frame
    void Update()
    {
        if(playerIsOn)
        {
            Player3DExample.Instance.gameObject.transform.position = assise.transform.position;
            Player3DExample.Instance.gameObject.transform.rotation = assise.transform.rotation;
            UIManager.Instance.canInteract = true;

            //|| Vector3.right * FloatingJoystick.Instance.Horizontal + new Vector3(0, 0, 1f) * FloatingJoystick.Instance.Vertical != Vector3.zero
            if (ContextualButtonInput.Instance.maintain || Player3DExample.Instance.joystick.Horizontal * Player3DExample.Instance.joystick.Horizontal > 0.2f )
            {                 
                anim.SetBool("go", true);
            }
            else
            {
                anim.SetBool("go", false);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("New State"))
            {
                if(hasDoneBalancoire)
                {
                    Player3DExample.Instance.canMove = true;
                    if (Player3DExample.Instance.isMoving)
                    {
                        playerIsOn = false;
                        Player3DExample.Instance.isSitted = false;
                    }
                }
                else
                {
                    Player3DExample.Instance.canMove = false;
                }
               
                
            }
            else
            {
                Player3DExample.Instance.canMove = false;
            }
        }
        else
        {
            anim.Play("New State");
        }


        


        


    }

    private void OnTriggerStay(Collider other)
    {
        if(!playerIsOn)
        {
            hasDoneBalancoire = false;
            UIManager.Instance.canInteract = true;
            if (ContextualButtonInput.Instance.pressed)
            {
                Player3DExample.Instance.canMove = false;
                playerIsOn = true;
                Player3DExample.Instance.isSitted = true;
            }
        }
    }

    public void HasDoneBalancoire()
    {
        hasDoneBalancoire = true;
    }
}
