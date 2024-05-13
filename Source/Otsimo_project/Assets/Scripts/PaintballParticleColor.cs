using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballParticleColor : MonoBehaviour
{
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void setColor(Color color) { 
    
        renderer.material.color = color;
    }
}
