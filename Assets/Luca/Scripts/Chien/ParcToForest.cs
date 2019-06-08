using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParcToForest : MonoBehaviour
{
    public Baboule_Controller stick;

    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player3DExample>() && stick.iterations >= 2)
        {
            UIManager.Instance.ChangeScene(nextScene);
            //SceneManager.LoadScene(nextScene);
        }
    }
}
