using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemOff : MonoBehaviour
{
    public GameObject setParent;
    public GameObject setActive;
    public GameObject setInactive;

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
            setParent.transform.parent = null;
            setParent.GetComponent<Animator>().enabled = false;
            setActive.SetActive(true);
            setInactive.SetActive(false);
        }
    }
}
