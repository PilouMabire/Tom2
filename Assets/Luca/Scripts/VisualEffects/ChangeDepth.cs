using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ChangeDepth : MonoBehaviour
    {
        public int newRenderQ = 2002;

        void Start()
        {
            // get all renderers in this object and its children:
            var renders = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renders.Length; i++)
            {
                renders[i].material.renderQueue = newRenderQ; // set their renderQueue
            }


        }
    }
