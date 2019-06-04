using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public bool canInteract;
    public GameObject contextualButton;

    int frame;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        frame++;
        if (frame >= 20)
        {
            canInteract = false;
            frame = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            contextualButton.SetActive(true);

            
        }
        else
        {
            contextualButton.SetActive(false);
        }

       
    }
}
