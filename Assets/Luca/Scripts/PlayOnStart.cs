using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayOnStart : MonoBehaviour
{

    public UnityEvent functionOnTrigger;
    public float delay = 0.1f;
    public bool dontPlayOnStart;

    // Start is called before the first frame update
    void Start()
    {
        if(!dontPlayOnStart)
        StartCoroutine(DelayingFunction());
        
    }

    IEnumerator DelayingFunction()
    {
        yield return new WaitForSeconds(delay);
        functionOnTrigger.Invoke();
    }

    public void DelayFunction()
    {
        StartCoroutine(DelayingFunction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
