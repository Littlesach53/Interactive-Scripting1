using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMGR : MonoBehaviour
{
    public void LoadScene(string sceneName = "Main Menu")
    {
SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("QuittingGame");
        Application.Quit();
    }
   
}
