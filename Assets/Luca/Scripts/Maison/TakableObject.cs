using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakableObject : MonoBehaviour
{
    public bool taken;
    public string objectID;

    public bool isMask;
    public GameObject mask;


    public AudioSource klaxonSound;

    public bool isTakable = true;

    public GameObject emplacementMainDroite;
    public GameObject emplacementMainGauche;


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
            if (ContextualButtonInput.Instance.maintain && Player3DExample.Instance.carrying == false && taken == false)
            {

                if(!isMask)
                {
                    if(klaxonSound != null)
                    {
                        klaxonSound.Play();
                    }
                    
                    Vibration.Vibrate(50);
                    taken = true;
                    transform.position = Player3DExample.Instance.forward.transform.position;
                    transform.SetParent(Player3DExample.Instance.transform);
                    transform.rotation = Quaternion.identity;
                    Player3DExample.Instance.carrying = true;
                    Player3DExample.Instance.carriedObject = this;
                }
                else

                if (collision.gameObject.GetComponent<Player3DExample>())

                {
                    if (!isMask)
                    {
                        Vibration.Vibrate(50);
                        taken = true;
                        transform.position = Player3DExample.Instance.forward.transform.position;
                        transform.SetParent(Player3DExample.Instance.transform);
                        Player3DExample.Instance.carrying = true;
                        Player3DExample.Instance.carriedObject = this ;
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
