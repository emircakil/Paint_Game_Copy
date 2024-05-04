using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D penTexture;
    [SerializeField] private Texture2D eraserTexture;
    [SerializeField] private Texture2D bucketTexture;
    [SerializeField] private Texture2D starTexture;
    private Vector2 cursorHotspot;
    string name;
    public void setPen()
    {
        cursorHotspot = new Vector2(penTexture.width / 2 - penTexture.width / 3.5f, penTexture.height / 2 - penTexture.height / 3.5f);
        Cursor.SetCursor(penTexture, cursorHotspot, CursorMode.Auto);
    }
    public void setErase() {

        cursorHotspot = new Vector2(eraserTexture.width / 2 - eraserTexture.width / 3.5f, eraserTexture.height / 2 - eraserTexture.height / 3.5f);
        Cursor.SetCursor(eraserTexture, cursorHotspot, CursorMode.Auto);
    }

    public void setStar() {

        cursorHotspot = new Vector2(starTexture.width / 2 , starTexture.height / 2 );
        Cursor.SetCursor(starTexture, cursorHotspot, CursorMode.Auto);
    }

    public void setBucket() {

        cursorHotspot = new Vector2(bucketTexture.width / 2 - bucketTexture.width / 3.5f, bucketTexture.height / 2 - bucketTexture.height / 3.5f);
        Cursor.SetCursor(bucketTexture, cursorHotspot, CursorMode.Auto);
    }
 
}
