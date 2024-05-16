using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;
    Color color_;
    ColorController colorController;
    [SerializeField] GameObject layerObject;
    LayerManager layerManager;



    private void Awake()
    {
        colorController = FindObjectOfType<ColorController>();
        layerManager = layerObject.gameObject.GetComponent<LayerManager>();
    }

    private void OnEnable()
    {
        activeLine = null;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                GameObject newLine = Instantiate(linePrefab);
                color_ = colorController.getColor();
                LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
                lineRenderer.material.color = color_;
                lineRenderer.sortingOrder = layerManager.getLayer();
                activeLine = newLine.GetComponent<Line>();
                activeLine.setColorName(colorController.getColorWName());
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);

        }
    }

    public void MakeInstance(List<LineData> list) {
       
        foreach (LineData data in list)
        {
            
            Vector2 pos = new Vector2(data.xPosition, data.yPosition);
            GameObject newPre = Instantiate(linePrefab);
            activeLine = newPre.GetComponent<Line>();
            LineRenderer lineRenderer = newPre.GetComponent<LineRenderer>();
            EdgeCollider2D edgeCollider = newPre.GetComponent<EdgeCollider2D>();

            string colorName = data.color;
            Debug.Log(colorName);
            Color newColor;
            switch (colorName)
            {
                case "black":
                    newColor = Color.black;
                    break;
                case "white":
                    newColor = Color.white;
                    break;
                case "blue":
                    newColor = Color.blue;
                    break;
                case "green":
                    newColor = Color.green;
                    break;
                case "orange":
                    newColor = new Color(1.0f, 0.5f, 0.0f);
                    break;
                case "purple":
                    newColor = new Color(0.5f, 0.0f, 0.5f);
                    break;
                case "red":
                    newColor = Color.red;
                    break;
                case "yellow":
                    newColor = Color.yellow;
                    break;
                default:
                    newColor = Color.black;
                    break;
            }
            lineRenderer.sortingOrder = data.layer;
            lineRenderer.material.color = newColor;
            activeLine.UpdateLineInstance(data.points, lineRenderer, edgeCollider );
         
          


        }

        /*
       foreach (LineData line in list)
       {

           foreach (var point in line.points) {

               Debug.Log(point);
           }
       }

       */
       
    }
}
