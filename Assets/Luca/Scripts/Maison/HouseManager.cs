using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{

    public List<Camera> cameras;


    [Header ("Vaiselle")]
    public GameObject vaiselleUI;
    public int nbrOfPlates;
    public Animator plateAnim;
    public SpngeController sponge;
    public bool canDoVaiselle = true;


    bool isDoingVaiselle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDoingVaiselle)
        {
            IsDoingVaiselle();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Vaiselle();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("azdazd");
            StartCoroutine(CameraSwitch(cameras[0]));

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(CameraSwitch(cameras[1]));
            print("azdazd");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(CameraSwitch(cameras[2]));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(CameraSwitch(cameras[3]));
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
        if(canDoVaiselle == true)
        {
            canDoVaiselle = false;
        Player3DExample.Instance.canMove = false;
        vaiselleUI.SetActive(true);
        isDoingVaiselle = true;

        }
    }

    IEnumerator CameraSwitch(Camera newCam)
    {
        print("oui");
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForEndOfFrame();
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newCam.transform.position, 0.05f);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newCam.orthographicSize, 0.05f);
        }
    }
}
