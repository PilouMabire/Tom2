using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancoireManager : MonoBehaviour
{
    public GameObject fugueItem;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fugue()
    {
        fugueItem.SetActive(true);
        anim.Play("fugue");
    }

    public void RetourMaison()
    {
        anim.Play("retourMaison");
        Player3DExample.Instance.canMove = false;
    }
}
