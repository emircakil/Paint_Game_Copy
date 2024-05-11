using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    Color color_;
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
    }
    public void setWhite()
    {

        color_ = Color.white;
    }
    public void setRed()
    {

        color_ = Color.red;
    }
    public void setOrange()
    {

        color_ = new Color(1.0f, 0.5f, 0.0f);
    }
    public void setPurple()
    {

        color_ = new Color(0.5f, 0.0f, 0.5f);
    }
    public void setYellow()
    {

        color_ = Color.yellow;
    }
    public void setBlue()
    {

        color_ = Color.blue;
    }
    public void setGreen()
    {

        color_ = Color.green;
    }
}
