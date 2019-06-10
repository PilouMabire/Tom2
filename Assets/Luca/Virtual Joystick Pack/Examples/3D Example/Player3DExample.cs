using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player3DExample : MonoBehaviour {

    public bool magnet = true;
    public bool canClimb = true;


    public bool isMoving;
    public bool isSitted;
    public float angleCorrector = -20;
    public float moveSpeed = 8f;
    public Joystick joystick;
    [HideInInspector]
    public Rigidbody rb;
    public static Player3DExample Instance;
    [HideInInspector]
    public float moveSpeedModifier = 1;
    [HideInInspector]
    public Vector3 joystickVelocity;


    public bool canMove = true;

    public bool carrying;

    [Header ("Assign")]
    public GameObject fxPif;
    public GameObject forward;
    public GameObject ray1;
    public GameObject ray2;
    public GameObject ray3;

    public GameObject mainGauche;
    public GameObject mainDroite;
    public GameObject tete;
    public Animator handsAnim;

    public Animator anim;

    public TakableObject carriedObject;

    [Header("SpecificShit")]
    public GameObject aspirateur;

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    
    

    private void Update()
    {

    }

    int countMagnet;

    

    void FixedUpdate()
    {


        if (canMove)
        {

            if (countMagnet > -5)
            {
                countMagnet--;
            }

            Vector3 moveVector = (Vector3.right * joystick.Horizontal + new Vector3(0, 0, 1f) * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {
                isMoving = true;
                transform.rotation = Quaternion.LookRotation(moveVector) * Quaternion.AngleAxis(angleCorrector, Vector3.up);
                rb.velocity = (transform.forward) * moveSpeed * moveSpeedModifier;

                //rb.AddForce(transform.forward * moveSpeed * moveSpeedModifier);
                //if(rb.velocity.magnitude > (transform.forward * moveSpeed * moveSpeedModifier).magnitude)
                //{
                //    rb.velocity = transform.forward * moveSpeed * moveSpeedModifier;
                //}


                if (canClimb)
                {
                    if (Physics.Linecast(transform.position, ray1.transform.position))
                    {
                        if (!Physics.Linecast(transform.position, ray2.transform.position))
                        {
                            print("climb");
                            transform.position += Vector3.up / 5;
                            countMagnet = 5;
                        }
                    }
                }

                if (magnet)
                {
                    if (countMagnet < 0)
                    {
                        if (!Physics.Linecast(transform.position, ray3.transform.position))
                        {
                            transform.position -= Vector3.up / 5;
                            countMagnet = 5;
                            print("magnet");
                        }
                    }
                }




            }
            else
            {
                isMoving = false;
            }
            joystickVelocity = moveVector * moveSpeed * moveSpeedModifier;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            fxPif.SetActive(true);
            handsAnim.Play("handsWalk");
            anim.Play("walk");
            //play run


        }
        else
        {

            handsAnim.CrossFade("handsIdle", 0.75f);
            if(isSitted)
            {
                //playsitted
                
                if(!anim.GetCurrentAnimatorStateInfo(0).IsName("assisIdle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("assis"))
                {
                    anim.Play("assis");
                }
                    fxPif.SetActive(false);
            }
            else
            {
                //play idle
                anim.Play("idle");
                fxPif.SetActive(true);
            }

        }
        if (carrying)
        {
            handsAnim.enabled = false;
            if(carriedObject != null)
            {
                mainDroite.transform.position = carriedObject.emplacementMainDroite.transform.position;
                mainGauche.transform.position = carriedObject.emplacementMainGauche.transform.position;
            }
        }
        else
        {
            handsAnim.enabled = true;
        }

        if (aspirateur != null)
        {
            if (aspirateur.activeInHierarchy)
            {
                mainGauche.SetActive(false);
                mainDroite.SetActive(false);
            }
            else
            {
                mainGauche.SetActive(true);
                mainDroite.SetActive(true);
            }
        }

        

    }

    public void CantMove()
    {
        canMove = false;
    }
    

}