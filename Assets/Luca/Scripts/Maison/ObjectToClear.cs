using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToClear : MonoBehaviour
{
    public string objectID;
    public GameObject setActive;

    public bool transitionThenClear;

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
