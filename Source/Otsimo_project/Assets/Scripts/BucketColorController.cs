using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class BucketColorController : MonoBehaviour
{
    Color color;
    private void Awake()
    {
        color = Color.black;
    }
    public Color getColor() {

        return color;
    }
    public void setBlack()
    {

        color = Color.black;
    }
    public void setWhite()
    {

        color = Color.white;
    }
    public void setRed()
    {

        color = Color.red;
    }
    public void setOrange()
    {

        color = new Color(1.0f, 0.5f, 0.0f);
    }
    public void setPurple()
    {

        color = new Color(0.5f, 0.0f, 0.5f);
    }
    public void setYellow()
    {

        color = Color.yellow;
    }
    public void setBlue()
    {

        color = Color.blue;
    }
    public void setGreen()
    {

        color = Color.green;
    }
}
