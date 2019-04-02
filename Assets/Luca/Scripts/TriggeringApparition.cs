using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringApparition : MonoBehaviour
{
    public RoomScript room;
    public string direction;

    private void OnTriggerEnter(Collider other)
    {
        if(room != null)
        {
            if (other.GetComponent<Player3DExample>())
            {
                if(direction == "here")
                {
                    room.roomApparition.MakeMainRoom();
                }
                else
                {
                    room.MakeRoomAppear(direction);
                    room.roomApparition.camHere = false;
                }
                
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (direction == "here")
        {
            if (other.GetComponent<Player3DExample>())
            {
                room.roomApparition.Disparition();
            }
        }
    }


}
