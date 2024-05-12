using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.U2D;

public class PaintballGun : MonoBehaviour
{
    public GameObject paintPrefab;
    SpriteRenderer spriteRenderer;
    PaintballPrefab paintballPrefab;
    [SerializeField] GameObject colorGameObject;
    ColorController colorController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {    
            colorController = colorGameObject.GetComponent<ColorController>();
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject paintInstance = Instantiate(paintPrefab, mousePosition, Quaternion.identity);
            paintballPrefab = paintInstance.GetComponent<PaintballPrefab>();
            spriteRenderer = paintInstance.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = paintballPrefab.getSprite(colorController.getColorWName());

        }
    }
}
