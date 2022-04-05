using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour
{
    [SerializeField] GameObject waveOne, waveTwo, waveThree, waveFour;

    private bool waveOneStarted = false, waveTwoStarted = false, waveThreeStarted = false, waveFourStarted = false;

    private void Update()
    {
        if (CountdownManagerScript.TimeLeft == 60)
        {
            waveOneStarted = true;
            waveOne.SetActive(true);
        }
        if (CountdownManagerScript.TimeLeft == 45)
        {
            waveTwoStarted = true;
            waveTwo.SetActive(true);
        }
        if (CountdownManagerScript.TimeLeft == 30)
        {
            waveThreeStarted = true;
            waveThree.SetActive(true);
        }
        if (CountdownManagerScript.TimeLeft == 15)
        {
            waveFourStarted = true;
            waveFour.SetActive(true);
        }
    }
}
