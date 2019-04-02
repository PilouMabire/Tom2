using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringParc : MonoBehaviour
{
    public Chien_Laisse chien;

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
            chien.isAttatchedToPlayer = false;
        }

    }
}
