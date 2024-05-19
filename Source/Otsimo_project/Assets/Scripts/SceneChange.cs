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
        setIsLoaded(true);
        SceneManager.LoadScene("SampleScene");
        
    }

    public void NewGame() {
        setIsLoaded(false);
        SceneManager.LoadScene("SampleScene");
    }
    private void setIsLoaded(bool value) { 
        isLoaded=value;
    }
    public bool getIsLoaded() {
        return isLoaded;
    }

}
