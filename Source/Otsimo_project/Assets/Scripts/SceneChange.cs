using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public bool isLoaded;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ContinueOnCurrentGame() {
        isLoaded = true;
        SceneManager.LoadScene("SampleScene");
    }

    public void NewGame() {
        isLoaded = false;
        SceneManager.LoadScene("SampleScene");
    }

    public bool getIsLoaded() { 
        return isLoaded;
    }


}
