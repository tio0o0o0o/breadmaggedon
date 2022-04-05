using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownManagerScript : MonoBehaviour
{
    public float TimeLeft { get; private set; } = 60f;
    [SerializeField] TMP_Text countdownText;
    public int Coin = 0;

    private void Start()
    {
        countdownText.text = TimeLeft.ToString();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(1f);
        TimeLeft--;
        countdownText.text = TimeLeft.ToString();
        if (TimeLeft > 0)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            GameStateManagerScript.StartGameover();
        }
    }
}
