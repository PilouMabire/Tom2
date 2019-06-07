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
        Instance = this;
        fondu.color = color;
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
        StartCoroutine(DelayForFade(sceneName));
    }

    IEnumerator DelayForFade(string sceneName)
    {
        fade.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
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
