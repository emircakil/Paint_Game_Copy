using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    private int layerCount = 0;
    GameObject sceneManagerObject;
    SceneChange sceneChange;
    private void Start()
    {
        sceneManagerObject = GameObject.FindGameObjectWithTag("SceneManager");
        sceneChange = sceneManagerObject.GetComponent<SceneChange>();
        ifLoaded(); 
    }

    void ifLoaded() {

        if (sceneChange.getIsLoaded())
        {
            int biggest = 0;

            GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();

            foreach (GameObject gO in objects)
            {

                if (gO.GetComponent<Renderer>() != null)
                {
                    Renderer renderer = gO.GetComponent<Renderer>();
                    int layer = renderer.sortingOrder;
                    if (biggest < layer && layer < 9000)
                    {
                        biggest = layer;
                    }
                }
            }
            layerCount = biggest +1;
        }
    }

    public int getLayer() {

        layerCount++;
        return layerCount;
    }
}
