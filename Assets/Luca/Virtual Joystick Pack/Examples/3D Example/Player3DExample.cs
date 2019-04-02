﻿using UnityEngine;

public class Player3DExample : MonoBehaviour {

    public float moveSpeed = 8f;
    public Joystick joystick;
    [HideInInspector]
    public Rigidbody rb;
    public static Player3DExample Instance;
    [HideInInspector]
    public float moveSpeedModifier = 1;
    [HideInInspector]
    public Vector3 joystickVelocity;

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () 
	{
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
            rb.velocity = moveVector * moveSpeed * moveSpeedModifier;
            
            //rb.AddForce(moveVector * moveSpeed);
            //transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
        }
        joystickVelocity = moveVector * moveSpeed * moveSpeedModifier;
    }

}