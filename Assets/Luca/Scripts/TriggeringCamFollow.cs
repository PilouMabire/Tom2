using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringCamFollow : MonoBehaviour
{
    public CameraFollow cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player3DExample>())
        {
            cam.followPlayer = false;
            cam.followObject = true;
            cam.objectToFollow = gameObject;
        }
        
    }
}
