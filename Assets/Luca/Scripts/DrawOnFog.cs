using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawOnFog : MonoBehaviour
{
    public GameObject trailPrefab;
    public Vector3 trailSize;
    public List<GameObject> trails;
    public List<float> timers;

    Vector3 velocity = new Vector3(0, 0, 0);

    int index = 1;

    float globalTimer;

    // Start is called before the first frame update
    void Start()
    {
        trailSize = trailPrefab.transform.localScale;
        for (int i = 0; i < 200; i++)
        {
            //trails.Add(Instantiate(trailPrefab, new Vector3(-10, -100, 10), Quaternion.identity));
            trails.Add(Instantiate(trailPrefab, transform));
            timers.Add(0);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < timers.Count; i++)
        {
            if(globalTimer > timers[i] + 1)
            {
                trails[i].transform.localScale = Vector3.Lerp(trails[i].transform.localScale, Vector3.zero, 0.14f - trails[i].transform.localScale.y/11);
            }
        }

        if (Input.GetMouseButton(0))
        {
            index++;
            
            trails[index].transform.localScale = trailSize;
            trails[index].SetActive(true);
            timers[index] = globalTimer;
            //trails[index].transform.LookAt(trails[index - 1].transform.position, new Vector3(-0.5f,0.5f,0));
            trails[index].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            if (index > 198)
            {
                index = 1;
            }
            //Instantiate(trailPrefab, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity);
        }
        else
        {
            globalTimer += Time.deltaTime;
        }
    }
}
