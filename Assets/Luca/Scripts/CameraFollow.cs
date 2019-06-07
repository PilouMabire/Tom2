using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    IEnumerator moveToTarget;

    public Camera cam;

    public bool followPlayer;
    public bool followObject;
    public GameObject objectToFollow;
    float cameraY;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cameraY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if(followPlayer)
        {
            transform.position = Vector3.Lerp(transform.position,  objectToFollow.transform.position, 0.1f);
            
        }
        else if(followObject)
        {
            transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position, 0.05f);
        }
       
    }

    public void MoveToTargetCaller(GameObject target)
    {
        
        moveToTarget = MoveToTarget(target);
        if(moveToTarget != null)
        {
            StopCoroutine(moveToTarget);
        }
        StartCoroutine(moveToTarget);
    }

    public IEnumerator MoveToTarget(GameObject target)
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(3, 17, -10), 0.1f);
        }
    }

    public IEnumerator CinematicTo(GameObject goTo)
    {
        
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForEndOfFrame();
            transform.rotation = Quaternion.Lerp(transform.rotation, goTo.transform.rotation, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, goTo.transform.position, Time.deltaTime);
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, Vector3.zero, Time.deltaTime);
            cam.transform.localRotation = Quaternion.Lerp(cam.transform.localRotation, Quaternion.identity, Time.deltaTime);
        }
        transform.rotation = goTo.transform.rotation;
        transform.position = goTo.transform.position;
        cam.transform.localPosition = Vector3.zero;
        cam.transform.localRotation = Quaternion.identity;
    }
}
