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

    public AudioSource kickSound;

    [Header ("Parc")]
    public bool parcsStick;
    public int iterations;
    public GameObject toDisable;
    public GameObject toEnable;
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
            UIManager.Instance.canInteract = true;
            transform.localPosition = localPosition;
            transform.localRotation = Quaternion.identity;
            if(chien)
            {
                chien.objectToFollow = gameObject;
            }
            if (ContextualButtonInput.Instance.maintain)
            {
                if(parcsStick)
                {
                    transform.position += transform.forward;
                }
                kickSound.Play();
                Vibration.Vibrate(100);
                rb.velocity = ((Player3DExample.Instance.transform.forward ) * Random.Range(9, 15));
                caughtByPlayer = false;
                transform.SetParent(null);
                col.enabled = true;
                canTake = false;
                StartCoroutine(CanTakeAgain());
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
            toEnable.SetActive(true);
        }
    }

    bool canTake = true;

    IEnumerator CanTakeAgain()
    {
        yield return new WaitForSeconds(0.2f);
        canTake = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player3DExample>() && iterations <2&& canTake)
        {
            //col.enabled = false;
            caughtByPlayer = true;
            rb.useGravity = false;
            if(parcsStick)
            {
                transform.position = Player3DExample.Instance.mainDroite.transform.position;
                transform.SetParent(Player3DExample.Instance.mainDroite.transform);
                col.enabled = false;
            }
            else
            {
                transform.position = Player3DExample.Instance.forward.transform.position;
                transform.SetParent(Player3DExample.Instance.transform);
                col.enabled = true;
            }
            
            localPosition = transform.localPosition;
        }

    }
    
}
