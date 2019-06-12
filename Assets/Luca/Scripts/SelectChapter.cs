using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChapter : MonoBehaviour
{
    public SpriteRenderer sprite;
    public string scene;
    public static SelectChapter selected;
    public static string chapterToGoTo;
    public string chapter;
    public AudioSource retourSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.canInteract = true;
        if (selected != this)
        {
            sprite.color = Color.clear;
        }

        if(ContextualButtonInput.Instance.pressed)
        {
            if(chapter == "Chapter 1")
            {
                retourSound.Play();
                UIManager.Instance.ChangeScene(scene);
            }
            
        }
    }

    private void OnMouseEnter()
    {
        sprite.color = Color.white;
        selected = this;
        chapterToGoTo = chapter;
    }


}
