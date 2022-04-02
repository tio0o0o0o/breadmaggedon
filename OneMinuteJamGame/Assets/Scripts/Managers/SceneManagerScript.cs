using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //public Text HStext;

    void OpenGameoverScene()
    {
        SceneManager.LoadScene("GameoverScene");
        //HStext.text = "Highscore:" + PlayerPrefs.GetInt("Highscore");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenGameplayScene()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    
    private void Start()
    {
        
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
