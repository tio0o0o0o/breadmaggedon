using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerScript : MonoBehaviour
{
    [HideInInspector] public enum gameStatesEnum
    {
        Gameplay, 
        Gameover,
    }

    //Current game state
    public static gameStatesEnum gameState = gameStatesEnum.Gameplay;
}