using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpngeController : MonoBehaviour
{
    public GameObject mask;
    public float moveSpeed = 8f;
    public Joystick joystick;
    [HideInInspector]
    public float moveSpeedModifier = 1;
    [HideInInspector]
    public Vector3 joystickVelocity;

    public GameObject forward;

    public List<GameObject> masks;



    int waiter;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + new Vector3(0, 0, 1f) * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            //transform.rotation = Quaternion.LookRotation(moveVector) * Quaternion.AngleAxis(-20, Vector3.up);
            transform.position += moveVector * moveSpeed * moveSpeedModifier;
            waiter++;
            if(waiter > 10)
            {
                var _mask = Instantiate(mask, transform.position, transform.rotation);
                masks.Add(_mask);
                waiter = 0;
            }
            
            //rb.AddForce(moveVector * moveSpeed);
            //transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
        }
        joystickVelocity = moveVector * moveSpeed * moveSpeedModifier;
    }

    public void ChangePlate()
    {
        for (int i = 0; i < masks.Count; i++)
        {
            Destroy(masks[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}