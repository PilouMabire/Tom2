using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noyade : MonoBehaviour
{
    public Animator anim;
    public bool canPress = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.canInteract = true;
        transform.position -= Vector3.up * Time.deltaTime * 4;

        if(ContextualButtonInput.Instance.pressed)
        {
            if(canPress)

            StartCoroutine(Remonte());
        }
    }

    IEnumerator Remonte()
    {
        canPress = false;
        anim.Play("Nage");
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForEndOfFrame();
            transform.position += Vector3.up/20;
        }
        yield return new WaitForSeconds(0.3f);
        canPress = true;
    }
}
