using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnDistance : MonoBehaviour
{
    public GameObject objectReference;
    public bool appear;
    public bool disapear;
    public float distanceToAppear;
    public float distanceToDisapear;

    public TestMaterialInstance matManager;

    public bool isAppeared;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(disapear)
        {
            if (Vector3.Distance(objectReference.transform.position, transform.position) > distanceToDisapear)
            {
                print("r");
                isAppeared = false;
                
                matManager.Disparition();
            }
        }
        
        if(appear)
        {
            if (Vector3.Distance(objectReference.transform.position, transform.position) < distanceToAppear)
            {
                print("r");
                isAppeared = true;
                matManager.Apparition();
               
            } 
        }
        
    }
}
