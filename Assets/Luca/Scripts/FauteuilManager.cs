using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauteuilManager : MonoBehaviour
{

    public Animator playerAnim;
    public Animator fauteuilAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("walk") )
        {
            if( !fauteuilAnim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            fauteuilAnim.Play("walk");
        }
        else
        {
            fauteuilAnim.Play("idle");
        }
    }
}
