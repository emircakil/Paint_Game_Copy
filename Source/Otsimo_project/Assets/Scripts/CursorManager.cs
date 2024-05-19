using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    /*
     This class created for just pc build. That's provides to see what you selected from tools in your cursor.
     
     */

    [SerializeField] private Texture2D penTexture;
    [SerializeField] private Texture2D eraserTexture;
    [SerializeField] private Texture2D bucketTexture;
    [SerializeField] private Texture2D starTexture;
    [SerializeField] private Texture2D paintballTexture;
    private Vector2 cursorHotspot;
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

    public void setPaintball()
    {
        cursorHotspot = new Vector2(paintballTexture.width / 2 - paintballTexture.width / 3.5f, paintballTexture.height / 2 - paintballTexture.height / 3.5f);
        Cursor.SetCursor(paintballTexture, cursorHotspot, CursorMode.Auto);
    }

}
