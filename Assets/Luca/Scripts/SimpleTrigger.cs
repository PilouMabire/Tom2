using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{
    public bool needInteraction;
    public UnityEvent functionOnTrigger;
    public bool triggerOnce;

    bool alreadyTriggered;

    public bool showHandOnCondition;

    // Start is called before the first frame update
    void Start()
    {
        if(needInteraction)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!needInteraction)
        {
            if (other.GetComponent<Player3DExample>())
            {
                if (!alreadyTriggered)
                {
                    functionOnTrigger.Invoke();

                }
                if (triggerOnce)
                {
                    alreadyTriggered = true;
                    
                }
                
                
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (needInteraction)
        {
            if(!showHandOnCondition)
            {
                if (other.GetComponent<Player3DExample>())
                {
                    UIManager.Instance.canInteract = true;
                }

                if (ContextualButtonInput.Instance.pressed)
                {
                    if (other.GetComponent<Player3DExample>())
                    {
                        functionOnTrigger.Invoke();
                    }
                }
            }
            else
            {
                if(!HouseManager.Instance.vaiselleDone)
                {
                    if(HouseManager.Instance.sponge.maskCount >= 14)
                    {
                        if (other.GetComponent<Player3DExample>())
                        {
                            UIManager.Instance.canInteract = true;
                        }

                        if (ContextualButtonInput.Instance.pressed)
                        {
                            if (other.GetComponent<Player3DExample>())
                            {
                                functionOnTrigger.Invoke();
                            }
                        }
                    }
                    else if(!HouseManager.Instance.sponge.isActiveAndEnabled)
                    {
                        if (other.GetComponent<Player3DExample>())
                        {
                            UIManager.Instance.canInteract = true;
                        }

                        if (ContextualButtonInput.Instance.pressed)
                        {
                            if (other.GetComponent<Player3DExample>())
                            {
                                functionOnTrigger.Invoke();
                            }
                        }
                    }
                    else
                    {
                        UIManager.Instance.canInteract = false;
                    }
                    
                }
                else
                {
                    Destroy(gameObject);
                    
                }
                
            }
            
           
        }
    }

    public void JustPlayFunction()
    {
        functionOnTrigger.Invoke();

    }
}
