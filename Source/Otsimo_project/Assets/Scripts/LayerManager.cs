using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    private int layerCount = 0;

    public int getLayer() {

        layerCount++;
        return layerCount;
    }
}
