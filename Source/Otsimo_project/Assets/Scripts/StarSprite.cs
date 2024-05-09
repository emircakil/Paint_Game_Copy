using UnityEngine;

public class PaintController : MonoBehaviour
{
    public GameObject paintPrefab; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
            GameObject paintInstance = Instantiate(paintPrefab, mousePosition, Quaternion.identity);
        }
    }
}
