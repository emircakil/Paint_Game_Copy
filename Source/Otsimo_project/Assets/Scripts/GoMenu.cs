using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenu : MonoBehaviour
{
    public GameObject saveObject;
    JsonWriteSystem saveSystem;
    GameObject sceneManagerObject;
    public GameObject starDrawObject;
    public GameObject paintballDrawObject;
    public GameObject lineDrawObject;
    public GameObject bucketDrawObject;

    private void Start()
    {
        saveSystem = saveObject.GetComponent<JsonWriteSystem>();
        sceneManagerObject = GameObject.FindGameObjectWithTag("SceneManager");
    }
    public void goBackMenu() {

        saveSystem.SaveToJson();
        Destroy(sceneManagerObject);
        Destroy(starDrawObject);
        Destroy(paintballDrawObject);
        Destroy(lineDrawObject);
        Destroy(bucketDrawObject);
        SceneManager.LoadScene("Menu");

    }

  
}
