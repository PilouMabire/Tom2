﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voiture : MonoBehaviour
{

    public GameObject UI;
    public Animator anim;
    public GameObject cam;

    public GameObject drawSystem;

    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);
    }

    void GoToChenil()
    {
        anim.Play("Go");
        StartCoroutine(WaitAndGoToScene());
    }

    IEnumerator WaitAndGoToScene()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(nextScene);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player3DExample>())
        {
            UI.SetActive(false);
            Player3DExample.Instance.gameObject.SetActive(false);
            GoToChenil();
            drawSystem.SetActive(true);
            
            
        }
        
    }
}
