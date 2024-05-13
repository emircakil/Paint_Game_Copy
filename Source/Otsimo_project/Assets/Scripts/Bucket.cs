using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    
    [SerializeField]Camera cam;
    Color color_;
    ColorController colorController;

    private void Awake()
    {
        colorController = FindObjectOfType<ColorController>();
    }
    private void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            color_ = colorController.getColor();
            cam.backgroundColor = color_;

        }

    }

    
}

    

