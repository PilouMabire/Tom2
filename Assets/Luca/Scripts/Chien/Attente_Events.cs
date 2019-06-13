using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attente_Events : MonoBehaviour
{

    public Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Event");
    }

 
    public IEnumerator Event()
    {
        yield return new WaitForSeconds(15f);
        doorAnim.Play("open");
    }
}
