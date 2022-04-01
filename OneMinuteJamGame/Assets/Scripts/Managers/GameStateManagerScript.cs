using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerScript : MonoBehaviour
{
    //**Be careful when making changes to this script. Many other scripts will be dependant on it.**

    [HideInInspector] public enum gameStatesEnum
    {
        Gameplay, 
        Gameover,
    }

    //Current game state
    public static gameStatesEnum gameState = gameStatesEnum.Gameplay;
}
