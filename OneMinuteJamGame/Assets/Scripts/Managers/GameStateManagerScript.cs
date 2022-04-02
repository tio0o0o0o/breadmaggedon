using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManagerScript : MonoBehaviour
{
    //**Be careful when making changes to this script. Many other scripts will be dependant on it.**

    public static event Action OnGameover = delegate { };

    public static void StartGameover()
    {
        OnGameover?.Invoke();
    }

    private void Start()
    {
        healthManagerScript.OnDeath += StartGameover;
    }
}
