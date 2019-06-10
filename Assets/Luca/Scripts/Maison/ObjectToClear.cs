using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToClear : MonoBehaviour
{
    public string objectID;
    public GameObject setActive;

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
        if(other.GetComponent<TakableObject>())
        {
            if(other.GetComponent<TakableObject>().objectID == objectID)
            {
                Destroy(gameObject);
                if(setActive)
                {
                    setActive.SetActive(true);
                }
            }
        }
    }
}
