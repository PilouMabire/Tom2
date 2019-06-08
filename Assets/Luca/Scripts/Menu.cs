using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    bool optionsOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
