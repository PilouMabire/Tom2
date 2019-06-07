using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{

    public bool isChapFinal;

    public List<Camera> cameras;
    public Animator anim;
    public GameObject triggerDaronne;
    public GameObject joystick;
    public AudioSource listSound;
    [Header ("Vaiselle")]
    public GameObject vaiselleUI;
    public int nbrOfPlates;
    public Animator plateAnim;
    public SpngeController sponge;
    public bool canDoVaiselle = true;
    bool isDoingVaiselle;
    public bool vaiselleDone;
    public GameObject vaiselleCheckBox;


    [Header("Aspirateur")]
    public GameObject aspirateur;
    public List<GameObject> taches;
    public bool aspirateurDone;
    public GameObject aspirateurCheckBox;

    [Header("Rangement")]
    public List<GameObject> objects;
    public bool rangementDone;
    public GameObject rangementCheckBox;

    [Header("Tasks")]
    public GameObject taskList;
    bool isOpeningTasks;

    int frame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isChapFinal)
        {
            AspirateurUpdate();
            RangementUpdate();
        }
        else
        {
            
        }
        

    }
    void RangementUpdate()
    {
        if (rangementDone == false)
        {
            if (objects[0] == null)
            {
                objects.RemoveAt(0);
            }

            if (objects.Count == 0)
            {
                rangementDone = true;
                rangementCheckBox.SetActive(true);
            }
        }
    }
    void AspirateurUpdate()
    {
        if (aspirateurDone == false)
        {
            if (aspirateur.activeInHierarchy)
            {
                frame++;
                if (frame == 10)
                {
                    Vibration.Vibrate(100);
                    frame = 0;
                }

            }
            if (taches[0] == null)
            {
                taches.RemoveAt(0);
            }

            if (taches.Count == 0)
            {
                Destroy(aspirateur);
                Player3DExample.Instance.carrying = false;
                aspirateurDone = true;
                aspirateurCheckBox.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isChapFinal)
        {
            if (isDoingVaiselle)
            {
                joystick.gameObject.SetActive(false);
                IsDoingVaiselle();
            }
            else
            {
                joystick.gameObject.SetActive(true);
            }

            if (vaiselleDone && rangementDone && aspirateurDone)
            {
                triggerDaronne.SetActive(true);
            }
        }
        
    }
    public void RoomSwitcher(int index)
    {
        StartCoroutine(CameraSwitch(cameras[index], index));
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
                sponge.ChangePlate();
                Player3DExample.Instance.canMove = true;
                vaiselleUI.SetActive(false);
                isDoingVaiselle = false;
                vaiselleDone = true;
                vaiselleCheckBox.SetActive(true);
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

    IEnumerator CameraSwitch(Camera newCam, int index)
    {
        switch (index)
        {
            case 0 :
                anim.Play("HouseCuisine");
                break;
            case 1:
                anim.Play("HouseSalon");
                break;
            case 2:
                anim.Play("HouseToilets");
                break;
            case 3:
                anim.SetTrigger("reset");
                break;
            case 4:
                anim.Play("HouseEtage");
                break;
            case 5:
                anim.CrossFade("HouseSdB", 0.75f);
                break;
            case 6:
                //anim.Play("HouseChambre");
                anim.CrossFade("HouseChambre", 0.75f);
                break;
            case 7:
                anim.CrossFade("HouseChambrePa", 0.75f);
                break;
            default:
                break;
        }
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForEndOfFrame();
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newCam.transform.position, 0.065f + i/150f);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newCam.orthographicSize, 0.05f + i/150f);
        }
    }

    public void InteractWithTasks()
    {
        if(isOpeningTasks)
        {
            CloseTasks();
        }
        else
        {
            OpenTasks();
        }
    }

    void OpenTasks()
    {
        listSound.Play();
        isOpeningTasks = true;
        Player3DExample.Instance.canMove = false;
        taskList.SetActive(true);
    }

    void CloseTasks()
    {
        taskList.SetActive(false);
        Player3DExample.Instance.canMove = true;
        isOpeningTasks = false;
    }

    public void DaronneArrive()
    {
        anim.Play("MereArrive");
        Player3DExample.Instance.canMove = false;
        RoomSwitcher(8);
    }

    public void Fuite()
    {
        anim.Play("Fuite");
        RoomSwitcher(8);
    }
}
