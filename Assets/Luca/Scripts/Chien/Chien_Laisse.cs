﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chien_Laisse : MonoBehaviour
{
    LineRenderer leadRenderer;
    Rigidbody rb;

    public AnimationCurve forceOverDistance;
     float leadDistance = 4.5f;
    public float basicLeadDist = 4.5f;
    public float interactionLeadDist = 2;
    public bool isAttatchedToPlayer = true;

    public bool followPlayer;
    public bool followObject;
    public GameObject objectToFollow;

    public float ChienSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leadRenderer = GetComponent<LineRenderer>();
    }

    Vector3 _lastPos = new Vector3();

    private void FixedUpdate()
    {

        LeadRendering();
        LeadAttraction();
        FollowObject();
        FollowPlayer();

        

        if (ContextualButtonInput.Instance.maintain)
        {
            leadDistance = interactionLeadDist;
        }
        else
        {
            leadDistance = basicLeadDist;
        }

    }

    void FollowPlayer()
    {
        if(followPlayer)
        {
            if(Player3DExample.Instance.joystickVelocity.magnitude > 1f)
            {
                //rb.velocity = Player3DExample.Instance.joystickVelocity * 1.1f;
                rb.AddForce(Player3DExample.Instance.joystickVelocity * ChienSpeed *20);
                transform.rotation = Quaternion.LookRotation(Vector3.Normalize(objectToFollow.transform.position - transform.position));
            }
            
        }
    }

    void FollowObject()
    {
        if (followObject && Vector3.Distance(transform.position, objectToFollow.transform.position) > 1.5f) 
        {
            transform.Translate(Vector3.Normalize( objectToFollow.transform.position - transform.position)
                * ChienSpeed * Time.deltaTime , Space.World);
            transform.rotation = Quaternion.LookRotation(Vector3.Normalize(objectToFollow.transform.position - transform.position));

        }
    }

    void LeadRendering()
    {
        if (isAttatchedToPlayer)
        {
            leadRenderer.SetPosition(0, transform.position);
            leadRenderer.SetPosition(1, Player3DExample.Instance.transform.position);
        }
        else
        {
            leadRenderer.positionCount = 0;
        }

    }

    void LeadAttraction()
    {
        if(isAttatchedToPlayer)
        {
            if (Mathf.Abs(Player3DExample.Instance.joystick.Horizontal + Player3DExample.Instance.joystick.Vertical) < 0.1)
            {
                Player3DExample.Instance.rb.velocity = forceOverDistance.Evaluate(Vector3.Distance(transform.position, Player3DExample.Instance.transform.position) / leadDistance)
            * (transform.position - Player3DExample.Instance.transform.position);
            }
            else
            {
                rb.velocity = -1* forceOverDistance.Evaluate(Vector3.Distance(transform.position, Player3DExample.Instance.transform.position) / leadDistance)
            * (transform.position - Player3DExample.Instance.transform.position);
            }
            if (Vector3.Distance(_lastPos, transform.position) > Vector3.Distance(Player3DExample.Instance.transform.position, transform.position) ||
            Vector3.Distance(Player3DExample.Instance.transform.position, transform.position) < 4f)
            {
                Player3DExample.Instance.moveSpeedModifier = Mathf.Lerp(Player3DExample.Instance.moveSpeedModifier, 1f, 0.1f);
            }
            else
            {
                Player3DExample.Instance.moveSpeedModifier = Mathf.Lerp(Player3DExample.Instance.moveSpeedModifier, 0.01f, 0.1f);
            }
            _lastPos = Player3DExample.Instance.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
