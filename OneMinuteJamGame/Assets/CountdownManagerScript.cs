using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownManagerScript : MonoBehaviour
{
    [SerializeField] float TimeLeft = 60f;
    [SerializeField] TextMeshPro countdownText;

    private void Start()
    {
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
    }
}
