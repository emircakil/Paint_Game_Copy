using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;
    Material material;
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
}
