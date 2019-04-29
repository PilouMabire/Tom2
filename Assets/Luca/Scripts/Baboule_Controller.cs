using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baboule_Controller : MonoBehaviour
{
    [HideInInspector]
    public bool caughtByPlayer;

    Rigidbody rb;
    Collider col;

    public Chien_Laisse chien;

    Vector3 localPosition;

    [Header ("Parc")]
    public bool parcsStick;
    public int iterations;
    public GameObject toDisable;
    public GameObject goTo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(caughtByPlayer)
        {
            transform.localPosition = localPosition;
            transform.localRotation = Quaternion.identity;
            if(chien)
            {
                chien.objectToFollow = gameObject;
            }
            if (ContextualButtonInput.Instance.maintain)
            {
                print("shhot");
                rb.velocity = (transform.forward * Random.Range(9, 15));
                caughtByPlayer = false;
                transform.SetParent(null);
                //col.enabled = true;
                rb.useGravity = true;
                if(parcsStick)
                {
                    iterations++;
                    
                }
                
            }
        }
        if (iterations >= 2)
        {
            transform.position = Vector3.Lerp(transform.position, goTo.transform.position, 0.01f);
            toDisable.SetActive(false);
            col.enabled = false;
            rb.useGravity = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player3DExample>() && iterations <2)
        {
            //col.enabled = false;
            caughtByPlayer = true;
            rb.useGravity = false;
            transform.position = Player3DExample.Instance.forward.transform.position;
            transform.SetParent(Player3DExample.Instance.transform);
            localPosition = transform.localPosition;
        }
    }
}
