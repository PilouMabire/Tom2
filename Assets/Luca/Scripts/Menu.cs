using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    bool optionsOpen;
    
 
  

    public void InteractOptions()
    {
        optionsOpen = !optionsOpen;
        if(optionsOpen)
        {
            OpenOptions();
        }
        else
        {
            CloseOptions();
        }
    }

    void OpenOptions()
    {
        Player3DExample.Instance.canMove = false;
    }

    void CloseOptions()
    {
        Player3DExample.Instance.canMove = true;
    }
}
