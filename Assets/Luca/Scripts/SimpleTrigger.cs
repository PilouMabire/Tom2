using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{
    public bool needInteraction;
    public UnityEvent functionOnTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
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
                functionOnTrigger.Invoke();
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (needInteraction)
        {
            if (ContextualButtonInput.Instance.maintain)
            {
                if (other.GetComponent<Player3DExample>())
                {
                    functionOnTrigger.Invoke();
                }
            }
           
        }
    }
}
