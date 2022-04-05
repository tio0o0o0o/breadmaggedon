using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour
{
    [SerializeField] GameObject waveOne, waveTwo, waveThree, waveFour;
    [SerializeField] CountdownManagerScript countdownManager;

    private bool waveOneStarted = false, waveTwoStarted = false, waveThreeStarted = false, waveFourStarted = false;

    private void Update()
    {
        if (countdownManager.TimeLeft == 60)
        {
            waveOneStarted = true;
            waveOne.SetActive(true);
        }
        if (countdownManager.TimeLeft == 45)
        {
            waveTwoStarted = true;
            waveTwo.SetActive(true);
        }
        if (countdownManager.TimeLeft == 30)
        {
            waveThreeStarted = true;
            waveThree.SetActive(true);
        }
        if (countdownManager.TimeLeft == 15)
        {
            waveFourStarted = true;
            waveFour.SetActive(true);
        }
    }
}
