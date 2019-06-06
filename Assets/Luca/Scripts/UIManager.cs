using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public bool canInteract;
    public GameObject contextualButton;

    bool desactivationSecurity;

    int frame;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        frame++;
        if (frame == 20)
        {
            canInteract = false;
        }
        else if(frame == 25)
        {
            desactivationSecurity = true;
            frame = 0;
            
        }
        else if(frame == 1)
        {
            desactivationSecurity = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(!canInteract && desactivationSecurity)
        {
            contextualButton.SetActive(false);

            
        }
        if(canInteract)
        {
            contextualButton.SetActive(true);
        }

       
    }
}
