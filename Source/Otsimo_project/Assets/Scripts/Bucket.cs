using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bucket : MonoBehaviour
{
    
    [SerializeField]Camera cam;
    Color color_ = Color.white;
    ColorController colorController;

    private void Awake()
    {
        colorController = FindObjectOfType<ColorController>();
    }
    private void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                color_ = colorController.getColor();
                cam.backgroundColor = color_;
            }
        }

    }
    public Color getColor() {

        return color_;
    }

    
}

    

