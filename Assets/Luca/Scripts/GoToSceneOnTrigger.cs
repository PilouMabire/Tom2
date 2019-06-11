using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneOnTrigger : MonoBehaviour
{

    public string sceneName;

    public float delay = 0.1f;

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
        if(other.GetComponent<Player3DExample>())
        {
            GoTo();
        }
    }

    public void GoTo()
    {
        StartCoroutine(DelayGoTo());
    }

    IEnumerator DelayGoTo()
    {
        yield return new WaitForSeconds(delay);
        UIManager.Instance.ChangeScene(sceneName);
    }

    public void ForceChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
