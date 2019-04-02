using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomApparition : MonoBehaviour
{
    public Animator anim;
    public bool isVisible;
    public RoomScript room;
    public bool camHere;

    public void Apparition()
    {
        if(isVisible == false)
        {
            anim.Play("RoomApparition");
            isVisible = true;
        }
    }

    public void AlreadyHere()
    {
        anim.Play("AlreadyHere");
        isVisible = true;
    }

    public void Disapear()
    {
        anim.Play("RoomDisparition");
        isVisible = false;
    }

    private void FixedUpdate()
    {
        CheckDistance();   
    }

    void CheckDistance()
    {
        //if(isVisible)
        //{
        //    if(Vector3.Distance(Player3DExample.Instance.transform.position, transform.position) > 8f)
        //    {
                
        //    }
        //    else if(Vector3.Distance(Player3DExample.Instance.transform.position, transform.position) < 5f && camHere == false)
        //    {
                
        //    }
        //}
    }
    public void MakeMainRoom()
    {
        camHere = true;
        GameManager.Instance.actualRoom = room;
        CameraFollow.Instance.MoveToTargetCaller(gameObject);
    }

    public void Disparition()
    {
        Disapear();
    }
}
