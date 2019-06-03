using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public bool canInteract;
    public GameObject contextualButton;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
