using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchToEraser : MonoBehaviour
{
    public GameObject eraser;
    public GameObject pen;
    public void OnClick() { 
    
        pen.SetActive(false);
        eraser.SetActive(true);

    }
}
