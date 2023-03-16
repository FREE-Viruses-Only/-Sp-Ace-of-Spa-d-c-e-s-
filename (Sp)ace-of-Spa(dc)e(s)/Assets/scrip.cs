using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                break;
            case GameState.SpawnMan:

                break;
            case GameState.GridAlt:
                break;
            case GameState.GridCalculation:
                break;
            case GameState.Movement:
                break;

        }
    }
}



    public enum GameState
    {
        GenerateGrid = 0,
        SpawnMan = 1,
        GridAlt = 2,
        GridCalculation = 3,
        Movement = 4,
    }

