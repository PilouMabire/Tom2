using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public RoomScript actualRoom;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    

    public void LoadScene(string sceneName)
    {
        UIManager.Instance.ChangeScene(sceneName);
        //SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeBlack()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public void Teleportation(GameObject newPos)
    {
        player.transform.position = newPos.transform.position;
    }
}
