using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject waveZeroObstacles, waveOneObstacles, waveTwoObstacles, waveThreeObstacles;
    [SerializeField] CountdownManagerScript countdownManagerScript;

    private bool waveZeroStarted = false, waveOneStarted = false, waveTwoStarted = false, waveThreeStarted = false;

    private void Update()
    {
        if (countdownManagerScript.TimeLeft < 60 && !waveZeroStarted)
        {
            waveZeroStarted = true;
            waveZeroObstacles.SetActive(true);
        }

        if (countdownManagerScript.TimeLeft < 45 && !waveOneStarted)
        {
            waveOneStarted = true;
            waveOneObstacles.SetActive(true);
        }

        if(countdownManagerScript.TimeLeft < 30 && !waveTwoStarted)
        {
            waveTwoStarted = true;
            waveTwoObstacles.SetActive(true);
        }

        if(countdownManagerScript.TimeLeft < 15 && waveTwoStarted)
        {
            waveThreeStarted = true;
            waveThreeObstacles.SetActive(true);
        }
    }
}
