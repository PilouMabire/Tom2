using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{


    [Header ("Vaiselle")]
    public GameObject vaiselleUI;
    public int nbrOfPlates;
    public Animator plateAnim;
    public SpngeController sponge;


    bool isDoingVaiselle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoingVaiselle)
        {
            IsDoingVaiselle();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Vaiselle();
        }
    }


    void IsDoingVaiselle()
    {
        if (ContextualButtonInput.Instance.pressed)
        {
            Vibration.Vibrate(100);
            if(nbrOfPlates > 00)
            {
                nbrOfPlates--;
                plateAnim.Play("ChangePlate");
                sponge.ChangePlate();
            }
            else
            {
                Player3DExample.Instance.canMove = true;
                vaiselleUI.SetActive(false);
                isDoingVaiselle = false;
            }
            
        }
    }

    public void Vaiselle()
    {
        Player3DExample.Instance.canMove = false;
        vaiselleUI.SetActive(true);
        isDoingVaiselle = true;
    }
}
