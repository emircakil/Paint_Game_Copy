using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    List<Vector2> points;

    EdgeCollider2D edgeCollider;

    private void Start()
    {
        edgeCollider = this.GetComponent<EdgeCollider2D>();
    }
    public List<Vector2> Points
    {
        get { return points; }
        set { points = value; }
    }

    public void UpdateLine(Vector2 position)
    {

        if (points == null)
        {

            points = new List<Vector2>();
            SetPoint(position);
        
            return;
        }

        if (Vector2.Distance(points.Last(), position) > .1f)
        {
            SetPoint(position);
            SetEdgeCollider(lineRenderer);
        }
    }
    void SetPoint(Vector2 point)
    {

        points.Add(point);

        lineRenderer.positionCount = points.Count;

        lineRenderer.SetPosition(points.Count - 1, point);
    }

    void SetEdgeCollider(LineRenderer edgeLineRenderer) { 
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0;  point < edgeLineRenderer.positionCount; point++) { 
        
            Vector3 lineRendererPoint = edgeLineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
        edgeCollider.SetPoints(edges);
    }
}