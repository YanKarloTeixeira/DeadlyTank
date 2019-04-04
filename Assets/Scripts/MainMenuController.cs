using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("ActualLevel", 1);
        SceneManager.LoadScene("Battle1");
    }
    public void TutorialGame()
    {
        SceneManager.LoadScene("Tutorial");
    }


    // What happens when I click the quit button?
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
