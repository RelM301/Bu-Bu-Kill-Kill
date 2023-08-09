using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private Slider audioSlider;
    public static UI ui;

    #endregion

    void Awake()
    {
        ui = this;
    }

    public float GetSliderValue()
    {
        return audioSlider.value;
    }

#region CONTROL DE ESCENAS
    public void StartGame()
    {
        LoadingScript.nextScene = 2;
        SceneManager.LoadSceneAsync(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadScreen()
    {
        LoadingScript.nextScene = 2;
        SceneManager.LoadSceneAsync(0);
    }
#endregion

public void ExitGame()
    {
#if UNITY_EDITOR
        print("Exit");
#endif
        Application.Quit();
    }
}
