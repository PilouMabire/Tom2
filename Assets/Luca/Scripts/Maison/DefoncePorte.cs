using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefoncePorte : MonoBehaviour
{
    public HouseManager houseManager;
    public Animator anim;

    public bool triggered;

    public int iterations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
            UIManager.Instance.canInteract = true;
            if(ContextualButtonInput.Instance.pressed)
            {
                
                iterations += 1;
                if(iterations > 5)
                {
                    anim.SetBool("success", true);
                }
                else
                {
                    anim.SetBool("enfonce", true);
                }
            }
            if (!ContextualButtonInput.Instance.maintain)
            {
                anim.SetBool("enfonce", false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player3DExample>())
        {
            houseManager.enabled = false;
            Player3DExample.Instance.canMove = false;
            anim.enabled = true;
            
            if(triggered == false)
            {
                anim.Play("IdleEnfoncePorte");
                triggered = true;
            }
            
        }
    }
}
