using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToClear : MonoBehaviour
{
    public string objectID;
    public GameObject setActive;

    public bool transitionThenClear;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TakableObject>())
        {
            if(other.GetComponent<TakableObject>().objectID == objectID)
            {
                if(transitionThenClear == false)
                {
                    Clear();
                }
                else
                {
                    StartCoroutine(FadeAndClear());

                }
                
            }
        }
    }

    IEnumerator FadeAndClear()
    {
        UIManager.Instance.DoubleFadeCall(1.5f);
        yield return new WaitForSeconds(1.2f);
        Clear();
    }

    public void Clear()
    {
        Destroy(gameObject);
        if (setActive)
        {
            setActive.SetActive(true);
        }
    }
}
