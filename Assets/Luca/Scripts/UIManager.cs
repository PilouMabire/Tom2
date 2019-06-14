using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public static UIManager Instance;

    public bool canInteract;
    public GameObject contextualButton;
    public Image fondu;
    public Animator fade;
    bool desactivationSecurity;

    public float aditionalDelay = 0;


    bool pause;

    [Header("FadeDeDébut")]
    public Color color = Color.black;
    public bool dontFade;

    [Header("FadeDeFin")]
    public Color color2 = Color.black;
    public bool dontFade2;


    int frame;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Instance = this;
        if(dontFade)
        {
            fondu.color = Color.clear;
            fondu.enabled = false;
        }
        else
        {
            fondu.color = color;
        }
        
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

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(DelayForFade(sceneName, "FadeOut"));
    }

    public void ChangeSceneSlowly(string sceneName)
    {
        StartCoroutine(DelayForFade(sceneName, "FadeOutSlowly"));
    }

    IEnumerator DelayForFade(string sceneName, string type)
    {
        UnPause(false);
        fondu.color = color2;
        fade.Play(type);
        if(type == "FadeOutSlowly")
        {
            yield return new WaitForSeconds(8f);
        }
        else
        {
            yield return new WaitForSeconds(1f + aditionalDelay);
        }
       
        SceneManager.LoadScene(sceneName);
    }

    public void DoubleFadeCall(float time)
    {
        StartCoroutine(DoubleFadeChoseTime(time));
    }
    public IEnumerator DoubleFadeChoseTime(float time)
    {
        fade.Play("FadeOut");
        yield return new WaitForSeconds(time);
        fondu.enabled = true;
        fade.Play("FadeIn");
    }

    public IEnumerator DoubleFade()
    {
        fade.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        fondu.enabled = true;
        fade.Play("FadeIn");
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

    bool gameIsPaused;

    public GameObject pauseMenu;
    public GameObject inGame;
    public Animator soundAnim;
    public Animator vibrationAnim;

    

    public void InteractWithPause()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Pause();
        }
        else
        {
            UnPause(true);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        inGame.SetActive(false);
        AudioListener.pause = true;
        if (soundOn)
        {
            soundAnim.Play("BoutonSonOn");
        }
        else
        {
            soundAnim.Play("BoutonSonOff");
        }

        if (Vibration.vibrateOn)
        {
            vibrationAnim.Play("BoutonVibrationOn");
        }
        else
        {
            vibrationAnim.Play("BoutonVibrationOff");
        }
    }

    void UnPause(bool igSetActive)
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        if(igSetActive == true)
        {
            inGame.SetActive(true);
        }
        
        AudioListener.pause = false;
        
    }

    public void ToogleVibration()
    {
        Vibration.vibrateOn = !Vibration.vibrateOn;
        if(Vibration.vibrateOn)
        {
            vibrationAnim.Play("BoutonVibrationOn");
        }
        else
        {
            vibrationAnim.Play("BoutonVibrationOff");
        }
    }

    public static bool soundOn = true;

    public void ToogleSound()
    {
        soundOn = !soundOn;
        if(soundOn)
        {
            soundAnim.Play("BoutonSonOn");
            AudioListener.volume = 1;
        }
        else
        {
            soundAnim.Play("BoutonSonOff");
            AudioListener.volume = 0;
        }
    }

   
}
