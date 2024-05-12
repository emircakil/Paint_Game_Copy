using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    Color color_;
    string name = "black";
    private void Awake()
    {
        color_ = Color.black;
    }
    public Color getColor()
    {

        return color_;
    }
    public void setBlack()
    {

        color_ = Color.black;
        name = "black";
    }
    public void setWhite()
    {

        color_ = Color.white;
        name = "white";
    }
    public void setRed()
    {

        color_ = Color.red;
        name = "red";
    }
    public void setOrange()
    {

        color_ = new Color(1.0f, 0.5f, 0.0f);
        name = "orange";
    }
    public void setPurple()
    {

        color_ = new Color(0.5f, 0.0f, 0.5f);
        name = "purple";
    }
    public void setYellow()
    {

        color_ = Color.yellow;
        name = "yellow";
    }
    public void setBlue()
    {

        color_ = Color.blue;
        name = "blue";
    }
    public void setGreen()
    {

        color_ = Color.green;
        name = "green";
    }

    public string getColorWName() { 
        
        return name;
    }
}
