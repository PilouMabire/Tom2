using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarqueManagement : MonoBehaviour
{
    public GameObject barque;

    public CameraFollow cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameplay()
    {
        cam.objectToFollow = barque;
        //barque.transform.position = gameObject.transform.position;
        barque.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
