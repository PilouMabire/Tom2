using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{

    public bool isChapFinal;

    public bool animHouse;

    bool blockSwitches;

    public List<Camera> cameras;
    public Animator anim;
    public GameObject triggerDaronne;
    public GameObject joystick;

    public AudioSource listSound;
    public AudioSource tacheFinie;
    public AudioSource listeFinie;
    public AudioSource vaisselleSound;
    public AudioSource aspirateurSound;
    public AudioSource fridgeVoice;
    public AudioSource mereVoice;

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
    public GameObject handL;
    public GameObject handR;

    [Header("Rangement")]
    public List<GameObject> objects;
    public bool rangementDone;
    public GameObject rangementCheckBox;

    [Header("Tasks")]
    public GameObject taskList;
    bool isOpeningTasks;

    [Header("LastChapter")]
    public Animator daronneDansLit;
    public TakableObject fauteil;

    int frame;

    public static HouseManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
                mereVoice.Play();
                tacheFinie.Play();
                rangementDone = true;
                rangementCheckBox.SetActive(true);
            }
        }
    }

    bool trigOnceAspi;

    void AspirateurUpdate()
    {
        if (aspirateurDone == false)
        {
            if (aspirateur.activeInHierarchy)
            {
                Player3DExample.Instance.carrying = true;
                frame++;
                if (frame == 10)
                {
                    Vibration.Vibrate(100);
                    frame = 0;
                }

                if (trigOnceAspi == false)
                {
                    trigOnceAspi = true;
                    aspirateurSound.Play();
                }

            }
            if (taches[0] == null)
            {
                taches.RemoveAt(0);
            }

            if (taches.Count == 0)
            {
                aspirateurSound.Stop();
                tacheFinie.Play();
                Destroy(aspirateur);
                Player3DExample.Instance.carrying = false;
                aspirateurDone = true;
                handL.SetActive(true);
                handR.SetActive(true);
                aspirateurCheckBox.SetActive(true);
            }
        }
    }

    bool trigOnce;

    // Update is called once per frame

    bool trigOnceVaisselle;

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
                if(trigOnce == false)
                {
                    trigOnce = true;
                    listeFinie.Play();
                }
            }
        }
        
    }
    public void RoomSwitcher(int index)
    {
        StartCoroutine(CameraSwitch(cameras[index], index));
    }

    void IsDoingVaiselle()
    {
        if (trigOnceVaisselle == false)
        {
            vaisselleSound.Play();
            trigOnceVaisselle = true;
        }
        if(sponge.maskCount > 14)
        {
            if (ContextualButtonInput.Instance.pressed)
            {
                Vibration.Vibrate(100);
                if (nbrOfPlates > 00)
                {
                    nbrOfPlates--;
                    plateAnim.Play("ChangePlate");
                    sponge.ChangePlate();
                }
                else
                {
                    vaisselleSound.Stop();
                    tacheFinie.Play();
                    sponge.ChangePlate();
                    Player3DExample.Instance.canMove = true;
                    vaiselleUI.SetActive(false);
                    isDoingVaiselle = false;
                    vaiselleDone = true;
                    vaiselleCheckBox.SetActive(true);
                }

            }
        }
        else
        {
            
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
        if(animHouse)
        {
            
            switch (index)
            {
                case 0:
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
        }
        
        if(!blockSwitches)
        {
            for (int i = 0; i < 50; i++)
            {
                yield return new WaitForEndOfFrame();
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newCam.transform.position, 0.065f + i / 150f);
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newCam.orthographicSize, 0.05f + i / 150f);
            }
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

    bool voicelinePlayed;

    void OpenTasks()
    {
        if (voicelinePlayed == false)
        {
            fridgeVoice.Play();
            voicelinePlayed = true;
        }
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
        blockSwitches = true;
    }

    public void DaronneArriveButHandicaped()
    {
        anim.Play("MereArriveButHandicaped");
        Player3DExample.Instance.canMove = false;
        RoomSwitcher(8);
        blockSwitches = true;
    }


    public void Fuite()
    {
        anim.Play("Fuite");
        RoomSwitcher(8);
        blockSwitches = true;
    }

    public void LeveMere()
    {
        daronneDansLit.Play("SleepingToAssis");
        fauteil.isTakable = true;
    }
}
