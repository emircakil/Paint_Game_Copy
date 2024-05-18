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
    string colorWString;

    private void Awake()
    {
        colorController = FindObjectOfType<ColorController>();
 
    }
    private void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            Touch touch = Input.touches[0];
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                color_ = colorController.getColor();
                cam.backgroundColor = color_;
            }
        }

    }
    public Color getColor() {

    Color color = cam.backgroundColor;
            
    return color;

    }


    
}

    

