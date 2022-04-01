using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerScript : MonoBehaviour
{
    public enum gameStatesEnum
    {
        Gameplay, 
        Gameover,
    }

    public static gameStatesEnum gameState = gameStatesEnum.Gameplay;
}
