using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringParc : MonoBehaviour
{
    public Chien_Laisse chien;
    public CameraFollow cam;
    public GameObject goToCam;

    public GameObject player;
    public GameObject playerGoTo;

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


        if (other.GetComponent<Player3DExample>())
        {
            StartCoroutine(EnteringInParc());
            chien.isAttatchedToPlayer = false;
        }


    }

    IEnumerator EnteringInParc()
    {
        StartCoroutine(UIManager.Instance.DoubleFade());
        yield return new WaitForSeconds(1f);
        cam.followPlayer = false;
        cam.objectToFollow = goToCam;
        cam.StartCoroutine(cam.CinematicTo(goToCam));
        player.transform.position = playerGoTo.transform.position;
        chien.gameObject.transform.position = playerGoTo.transform.position + new Vector3(1, 0, 1);
    }
}
