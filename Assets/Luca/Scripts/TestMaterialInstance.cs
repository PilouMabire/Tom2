using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMaterialInstance : MonoBehaviour
{

    public Material mat;
    Material _mat;
    // Start is called before the first frame update
    void Start()
    {
        _mat = Instantiate<Material>(mat);
        GetComponent<Renderer>().material = _mat;
        _mat.SetColor("_Additional", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
