using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayOnStart : MonoBehaviour
{

    public UnityEvent functionOnTrigger;
    public float delay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayingFunction());
        
    }

    IEnumerator DelayingFunction()
    {
        yield return new WaitForSeconds(delay);
        functionOnTrigger.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
