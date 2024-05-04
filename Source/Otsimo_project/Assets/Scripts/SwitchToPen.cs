using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchToPen : MonoBehaviour
{
    public GameObject eraser;
    public GameObject pen;

    public void OnClick() { 
    
        eraser.SetActive(false);
        pen.SetActive(true);
     
    }
}
