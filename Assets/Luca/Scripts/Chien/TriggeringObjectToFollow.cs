using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringObjectToFollow : MonoBehaviour
{
    Chien_Laisse chien;

    public GameObject objectToFollow;

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
        chien = other.GetComponent<Chien_Laisse>(); 
        if(chien)
        {
            chien.objectToFollow = objectToFollow;
            chien.ChienSpeed = Random.Range(4f, 4.5f);
        }
    }
}
