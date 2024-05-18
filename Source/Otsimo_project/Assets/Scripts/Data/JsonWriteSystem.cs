using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

public class JsonWriteSystem : MonoBehaviour
{
    public GameObject starDrawObject;
    StarSprite star;
    public GameObject paintballDrawObject;
    PaintballGun paintball;
    public GameObject lineDrawObject;
    Line line;
    LineGenerator lineGenerator;
    public GameObject bucketDrawObject;
    Bucket bucket;
    public Camera mainCamera;
    GameObject sceneManagerObject;
    SceneChange sceneChange;
    bool isLoaded;

    private void Awake()
    {
        sceneManagerObject = GameObject.FindGameObjectWithTag("SceneManager");
        sceneChange = sceneManagerObject.GetComponent<SceneChange>();
        isLoaded = sceneChange.getIsLoaded();
        star = starDrawObject.GetComponent<StarSprite>();
        paintball = paintballDrawObject.GetComponent<PaintballGun>();
        line = lineDrawObject.GetComponentInChildren<Line>();
        lineGenerator = lineDrawObject.GetComponent<LineGenerator>();
        bucket = bucketDrawObject.GetComponentInChildren<Bucket>();
        Debug.Log(isLoaded);

        Load();
    
    }

    public void SaveToJson() {
        SaveBucket();
        SaveStars();
        SaveLines();
        SavePaintballs();
        
    }

    public void SaveBucket() {

        BucketData data = new BucketData(); 
        data.color = bucket.getColor();
        string json = JsonUtility.ToJson(data);
        string path = Application.dataPath + "/Saves/BucketDataFile.json";
        File.WriteAllText(path, json);
    }
    public void SavePaintballs()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("PaintballGun");
        PaintballData data = new PaintballData(); 
        var sb = new StringBuilder();

        foreach (GameObject obj in objects)
        {

            PaintballPrefab paintballPrefab = obj.GetComponent<PaintballPrefab>();
            Renderer render = obj.GetComponent<Renderer>();
            data.colorWName = paintballPrefab.getSpriteName();
            data.xPosition = obj.transform.position.x;
            data.yPosition = obj.transform.position.y;
            data.zPosition = obj.transform.position.z;
            data.layer = render.sortingOrder;

            string json = JsonUtility.ToJson(data, true);
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
            Renderer render = obj.GetComponent<Renderer>();
            data.xPosition = obj.transform.position.x;
            data.yPosition = obj.transform.position.y;
            data.zPosition = obj.transform.position.z;
            data.layer = render.sortingOrder;

            string json = JsonUtility.ToJson(data, true);
            
            sb.AppendLine(json + "\n");

        }

        string path = Application.dataPath + "/Saves/StarsDataFile.json";
        File.WriteAllText(path, sb.ToString());
    }

    public void SaveLines()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Line");
        LineData data = new LineData();
        var sb = new StringBuilder();

        foreach(GameObject obj in objects)
        {
            Renderer render = obj.GetComponent<Renderer>();
            line = obj.GetComponent<Line>();
            data.color = line.getColorName();
            data.points = line.getPoints();
            data.xPosition = obj.transform.position.x;
            data.yPosition = obj.transform.position.y;
            data.zPosition= obj.transform.position.z;
            data.layer = render.sortingOrder;

            string json = JsonUtility.ToJson(data, true);
            sb.AppendLine("@"+json+ '\n');

        }

        string path = Application.dataPath + "/Saves/LineDataFile.json";
        File.WriteAllText (path, sb.ToString());

    }
    public void Load()
    {
        isLoaded = sceneChange.getIsLoaded();
        if (isLoaded)
        {
            LoadBucket();
            LoadStars();
            LoadPaintballs();
            LoadLines();
        }

        starDrawObject.SetActive(false);
        paintballDrawObject.SetActive(false);
        bucketDrawObject.SetActive(false);

    }


 
    public void LoadBucket() {

        string bucketPath = Application.dataPath + "/Saves/BucketDataFile.json";

        if (File.Exists(bucketPath))
        {

            string jsonData = File.ReadAllText(bucketPath);
            BucketData data = new BucketData();
            data = JsonUtility.FromJson<BucketData>(jsonData);
            mainCamera.backgroundColor = data.color;
        }
    }
    public void LoadLines() {

        string linePath = Application.dataPath + "/Saves/LineDataFile.json";
        List<LineData> lineDataList = new List<LineData>();

        if (File.Exists(linePath))
        {
            string jsonData = File.ReadAllText(linePath);
            string[] lineDataJson = jsonData.Split('@');

         

            foreach(string json in lineDataJson) {

                if (json != lineDataJson[0]) {

                    string json_ = "" + json;
          
                    LineData data = JsonUtility.FromJson<LineData>(json_);
                    lineDataList.Add(data);
                }
            }
        }
        else {
            Debug.LogError("Line data file not found!");
        }
        
        lineGenerator.MakeInstance(lineDataList);
        
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
            Debug.LogError("Paintball data file not found!");
        }

        paintball.MakeInstance(paintballDataList);

    }

    private void OnApplicationQuit()
    {
        SaveToJson();
        
    }
}
