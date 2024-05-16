using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class JsonWriteSystem : MonoBehaviour
{
    public GameObject starDrawObject;
    StarSprite star;
    
    private void Start()
    {
      star = starDrawObject.GetComponent<StarSprite>();
    }

    public void SaveToJson() {

        SaveStars();
        SaveLines();
        SavePaintballs();

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
            Debug.Log(json.ToString());
            sb.AppendLine(json + "\n");

        }

        string path = Application.dataPath + "/Saves/StarsDataFile.json";
        File.WriteAllText(path, sb.ToString());
    }

    public void LoadStar()
    {
        string path = Application.dataPath + "/Saves/StarsDataFile.json";
        List<StarData> starDataList = new List<StarData>();

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            string[] starDataJson = jsonData.Split('{');

            foreach (string json in starDataJson)
            {
                if (json != starDataJson[0])
                {


                    string json_ = "{" + json;
                    Debug.Log(json_);
                    StarData data = JsonUtility.FromJson<StarData>(json_);
                   
                    
                    StarData starObject = new StarData();
                    starObject.xPosition = data.xPosition;
                    starObject.yPosition = data.yPosition;
                    starObject.zPosition = data.zPosition;
                    starObject.layer = data.layer;
                    starDataList.Add(starObject);
                    
                }
            }
        }
        else
        {
            Debug.LogError("Star data file not found!");
        }

       star.MakeInstance(starDataList);

    }

    

    public void SavePaintballs() {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("PaintballGun");

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
