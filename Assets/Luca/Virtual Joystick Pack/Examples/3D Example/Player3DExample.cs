using UnityEngine;

public class Player3DExample : MonoBehaviour {

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

    public GameObject forward;

    public bool canMove = true;

    public bool carrying;

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    void FixedUpdate () 
	{
        if(canMove)
        {
            Vector3 moveVector = (Vector3.right * joystick.Horizontal + new Vector3(0, 0, 1f) * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveVector) * Quaternion.AngleAxis(angleCorrector, Vector3.up);
                rb.velocity = (transform.forward) * moveSpeed * moveSpeedModifier;

                //rb.AddForce(transform.forward * moveSpeed * moveSpeedModifier);
                //if(rb.velocity.magnitude > (transform.forward * moveSpeed * moveSpeedModifier).magnitude)
                //{
                //    rb.velocity = transform.forward * moveSpeed * moveSpeedModifier;
                //}

            }
            joystickVelocity = moveVector * moveSpeed * moveSpeedModifier;
        }

        


    }

}