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
    private void Start()
    {
        activeLine = null;
    }

    private void OnEnable()
    {
        activeLine = null;
    }
    void Update()
    {
        Touch touch;
        if (Input.GetMouseButtonDown(0))
        {

            touch = Input.touches[0];
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                GameObject newLine = Instantiate(linePrefab);
                color_ = colorController.getColor();
                LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
                lineRenderer.material.color = color_;
                lineRenderer.sortingOrder = layerManager.getLayer();
                activeLine = newLine.GetComponent<Line>();
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            touch = Input.touches[0];
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeLine.UpdateLine(mousePos);
            }
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
           
            lineRenderer.sortingOrder = data.layer;
            lineRenderer.material.color = data.color;
            activeLine.UpdateLineInstance(data.points, lineRenderer, edgeCollider );
         

        }
       
    }
}
