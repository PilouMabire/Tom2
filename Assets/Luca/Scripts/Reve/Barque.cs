using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barque : MonoBehaviour
{

    public Joystick joystick;
    public Rigidbody rb;
    public float moveSpeed;
    public float angleCorrector;

    public GameObject graph;

   

    // Update is called once per frame
    void Update()
    {
        //graph.transform.position = transform.position;
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + new Vector3(0, 0, 1f) * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveVector) * Quaternion.AngleAxis(angleCorrector , Vector3.up), 0.11f);
            rb.velocity = (transform.forward) * moveSpeed * 2;

        }
    }
}
