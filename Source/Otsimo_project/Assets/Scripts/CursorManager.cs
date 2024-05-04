using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D penTexture;
    [SerializeField] private Texture2D eraserTexture;
    private Vector2 cursorHotspot;
    void Start()
    {
        cursorHotspot = new Vector2(penTexture.width/2 - penTexture.width/3.5f, penTexture.height/ 2 - penTexture.height / 3.5f);
        Cursor.SetCursor(penTexture, cursorHotspot, CursorMode.Auto);
    }

 
}
