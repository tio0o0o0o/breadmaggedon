using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI HStext;

    private void Start()
    {
        HStext.text = "Highscore:" + PlayerPrefs.GetInt("Highscore");
    }
}
