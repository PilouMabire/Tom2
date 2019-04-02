using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMaterialInstance : MonoBehaviour
{
    public float parameter = 1;

    public List<Renderer> rends;
    public List<Material> _mats;
    // Start is called before the first frame update
    void Start()
    {
        //_mats.Capacity = rends.Count;
        for (int i = 0; i < rends.Count; i++)
        {
            for (int m = 0; m < rends[i].materials.Length; m++)
            {
                _mats.Add(Instantiate<Material>(rends[i].materials[m]));
                rends[i].materials[m] = _mats[i +m];
            }
            
        }
        //UpdateMaterials();


    }

    public void UpdateMaterials()
    {
        for (int i = 0; i < rends.Count; i++)
        {
            for (int m = 0; m < rends[i].materials.Length; m++)
            {
                rends[i].materials[m].SetFloat("_Displace", parameter);
            }
            
        }
    } 

    // Update is called once per frame
    void Update()
    {
        UpdateMaterials();
    }
}
