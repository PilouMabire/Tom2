using UnityEngine;

public class Player3DExample : MonoBehaviour {

    public bool isMoving;
    public GameObject fxPif;
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

    public GameObject ray1;
    public GameObject ray2;
    public GameObject ray3;

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    int countMagnet;

    void FixedUpdate () 
	{
       
        
        if(canMove)
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
                if(Physics.Linecast(transform.position, ray1.transform.position))
                {
                    if (!Physics.Linecast(transform.position, ray2.transform.position))
                    {
                        transform.position += Vector3.up/5;
                        countMagnet = 5;
                    }
                }
                if(countMagnet < 0)
                {
                    if (!Physics.Linecast(transform.position, ray3.transform.position))
                    {
                        transform.position -= Vector3.up / 5;
                        countMagnet = 5;
                        print("magnet");
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

        if(isMoving)
        {
            fxPif.SetActive(true);
        }
        else
        {
            fxPif.SetActive(false);
        }

        


    }

}