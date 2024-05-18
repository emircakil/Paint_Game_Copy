using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenu : MonoBehaviour
{
    public GameObject saveObject;
    JsonWriteSystem saveSystem;

    private void Start()
    {
        saveSystem = saveObject.GetComponent<JsonWriteSystem>();
    }
    public void goBackMenu() {
        saveSystem.SaveToJson();
        SceneManager.LoadScene("Menu");
    }
}
