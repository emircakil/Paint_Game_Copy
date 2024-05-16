using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameObjectData
{
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public float xRotation;
    public float yRotation;
    public float zRotation;
   

    public GameObjectData(float xPosition, float yPosition, float zPosition, float xRotation, float yRotation, float zRotation)
    {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.zPosition = zPosition;
        this.xRotation = xRotation;
        this.yRotation = yRotation;
        this.zRotation = zRotation;
    }

    public GameObjectData() {

        xPosition = 1;
        yPosition = 1;
        zPosition = 1;
        xRotation = 1;
        yRotation = 1;
        zRotation = 1;
    }
}
