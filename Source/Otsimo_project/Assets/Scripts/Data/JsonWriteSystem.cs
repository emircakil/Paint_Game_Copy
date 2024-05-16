using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class JsonWriteSystem : MonoBehaviour
{
    public GameObject starDrawObject;
    StarSprite star;
    public GameObject paintballDrawObject;
    PaintballGun paintball;
    
    private void Start()
    {
      star = starDrawObject.GetComponent<StarSprite>();
      paintball = paintballDrawObject.GetComponent<PaintballGun>();
    }

    public void SaveToJson() {

        SaveStars();
        SaveLines();
        SavePaintballs();

    }
    public void SavePaintballs()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("PaintballGun");
        PaintballData data = new PaintballData(); 
        var sb = new StringBuilder();

        foreach (var obj in objects)
        {
            PaintballPrefab paintballPrefab = obj.GetComponent<PaintballPrefab>();

            data.colorWName = paintballPrefab.getSpriteName();
            data.xPosition = obj.transform.position.x;
            data.yPosition = obj.transform.position.y;
            data.zPosition = obj.transform.position.z;
            data.layer = obj.layer;

            string json = JsonUtility.ToJson(data, true);
            Debug.Log(json.ToString());
            sb.AppendLine(json + "\n");

        }

        string path = Application.dataPath + "/Saves/PaintballDataFile.json";
        File.WriteAllText(path, sb.ToString());

    }
    public void SaveStars() {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Star");
        StarData data = new StarData();
        var sb = new StringBuilder();

        foreach (GameObject obj in objects)
        {
            
            data.xPosition = obj.transform.position.x;
            data.yPosition = obj.transform.position.y;
            data.zPosition = obj.transform.position.z;
            data.layer = obj.layer;

            string json = JsonUtility.ToJson(data, true);
            
            sb.AppendLine(json + "\n");

        }

        string path = Application.dataPath + "/Saves/StarsDataFile.json";
        File.WriteAllText(path, sb.ToString());
    }

    public void Load()
    {
       LoadStars();
       LoadPaintballs();

       

    }

    public void LoadStars() {
        string starPath = Application.dataPath + "/Saves/StarsDataFile.json";
        List<StarData> starDataList = new List<StarData>();

        if (File.Exists(starPath))
        {
            string jsonData = File.ReadAllText(starPath);
            string[] starDataJson = jsonData.Split('{');

            foreach (string json in starDataJson)
            {
                if (json != starDataJson[0])
                {


                    string json_ = "{" + json;
                    Debug.Log(json_);
                    StarData data = JsonUtility.FromJson<StarData>(json_);
                    starDataList.Add(data);

                }
            }
        }
        else
        {
            Debug.LogError("Star data file not found!");
        }
        star.MakeInstance(starDataList);

    }
    public void LoadPaintballs() {

        string paintballPath = Application.dataPath + "/Saves/PaintballDataFile.json";
        List<PaintballData> paintballDataList = new List<PaintballData>();
        if (File.Exists(paintballPath))
        {

            string jsonData = File.ReadAllText(paintballPath);
            string[] paintballDataJson = jsonData.Split('{');

            foreach (string json in paintballDataJson)
            {
                if (json != paintballDataJson[0])
                {

                    string json_ = "{" + json;
                    Debug.Log(json_);
                    try
                    {
                        PaintballData data = JsonUtility.FromJson<PaintballData>(json_);
                        paintballDataList.Add(data);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Failed to deserialize JSON: {ex.Message}");
                    }
                    
                    

                }
            }

        }
        else
        {
            Debug.LogError("Star data file not found!");
        }

        paintball.MakeInstance(paintballDataList);

    }


    public void SaveLines() {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Line");
    }

    /*
    public void SaveToJson() {

        GameObjectData data = new GameObjectData(1,1,1,1,1,1);
     
        string jsonString = JsonUtility.ToJson(line, true);
        Debug.Log(jsonString);
       // string path = Application.dataPath + "/Saves/GameObjectDataFile.json";
        //File.WriteAllText(Application.dataPath + path, jsonString);
    }

    public void LoadFromJson() {

        string path = Application.dataPath + "/Saves/GameObjectDataFile.json";
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Saves/GameObjectDataFile.json");
            GameObjectData data = JsonUtility.FromJson<GameObjectData>(jsonString);
        }
        else {

            Debug.Log("Json file couldn't found");
        }

    }



    SaveLoadObjects data = new SaveLoadObjects();
     Debug.Log("Saving file as level" + levelInt + "...");
     GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
     var sb = new StringBuilder();

     foreach (GameObject obj in objects)
     {
         data.objName = obj.name;
         data.posX = obj.transform.position.x;
         data.posY = obj.transform.position.y;
         data.posZ = obj.transform.position.z;
         string json = JsonUtility.ToJson(data, true);
         Debug.Log(json.ToString());
         sb.AppendLine(json);
     }

File.WriteAllText("level" + levelInt + ".phbl", sb.ToString());



    */
}
