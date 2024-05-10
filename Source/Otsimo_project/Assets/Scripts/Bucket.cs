using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    
    [SerializeField]Camera cam;
    Color color;
    BucketColorController bucketColorController;

    private void Awake()
    {
        bucketColorController = FindObjectOfType<BucketColorController>();
    }
    private void Update()
    {
     
        

        if (Input.GetMouseButtonDown(0))
        {
            color = bucketColorController.getColor();
            cam.backgroundColor = color;

        }

    }

    
}

    

