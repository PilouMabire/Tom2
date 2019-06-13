using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSelectedChapter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SelectChapter.chapterToGoTo == null)
        {
            SelectChapter.chapterToGoTo = "Chapter 1";
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player3DExample>())
        {
            GoToScene();


        }
    }

    public void GoToScene()
    {
        UIManager.Instance.ChangeScene(SelectChapter.chapterToGoTo);
    }
}
 