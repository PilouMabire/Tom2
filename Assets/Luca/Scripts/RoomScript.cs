using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [Tooltip ("Est ce que la salle est affichée au début du jeu")]
    public bool alreadyHere;




    [Header ("Prog")]
    public RoomScript LeftRoom;
    public RoomScript RightRoom;
    public RoomScript BottomRoom;
    public RoomScript TopRoom;
    [Space]
    public RoomApparition roomApparition;

    public void Start()
    {
        if(alreadyHere)
        {
            roomApparition.AlreadyHere();
        }
    }

    public void MakeRoomAppear(string room)
    {
        switch (room)
        {
            case "left":
                LeftRoom.roomApparition.Apparition();
                break;

            case "right":
                RightRoom.roomApparition.Apparition();
                break;

            case "top":
                TopRoom.roomApparition.Apparition();
                break;
                
            case "bottom":
                BottomRoom.roomApparition.Apparition();
                break;

            default:

                break;
                
        }
    }
}
