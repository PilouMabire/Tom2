using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemOff : MonoBehaviour
{
    public GameObject setParent;
    public GameObject setActive;
    public GameObject setInactive;

  

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
