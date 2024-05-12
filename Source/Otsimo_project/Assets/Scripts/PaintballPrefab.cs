using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballPrefab : MonoBehaviour
{
    Sprite sprite;

    [SerializeField] Sprite blackSprite;
    [SerializeField] Sprite whiteSprite;
    [SerializeField] Sprite blueSprite;
    [SerializeField] Sprite greenSprite;
    [SerializeField] Sprite orangeSprite;
    [SerializeField] Sprite purpleSprite;
    [SerializeField] Sprite redSprite;
    [SerializeField] Sprite yellowSprite;

    private void Start()
    {
        float randomRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f,0f,randomRotation);
    }

    public Sprite getSprite(string color) {

        switch (color)
        {
            case "black":
                sprite = blackSprite;
                break;
            case "white":
                sprite = whiteSprite;
                break;
            case "blue":
                sprite = blueSprite;
                break;
            case "green":
                sprite = greenSprite;
                break;
            case "orange":
                sprite = orangeSprite;
                break;
            case "purple":
                sprite = purpleSprite;
                break;
            case "red":
                sprite = redSprite;
                break;
            case "yellow":
                sprite = yellowSprite;
                break;
            default:
                sprite = blackSprite;
                break;
        }
        return sprite;
          
    }
}
