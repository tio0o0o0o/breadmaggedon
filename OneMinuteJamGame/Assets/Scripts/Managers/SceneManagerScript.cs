using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    void OpenGameoverScene()
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenGameplayScene()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    private void Awake()
    {
        GameStateManagerScript.OnGameover += OpenGameoverScene;
    }

    private void OnDestroy()
    {
        GameStateManagerScript.OnGameover -= OpenGameoverScene;
    }
}
