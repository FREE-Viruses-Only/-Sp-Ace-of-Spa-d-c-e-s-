using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    // Start is called before the first frame update
    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridBugMang.Instance.GenerateGrid();
                break;
            case GameState.SpawnMan:
                ManManager.Instance.SpawnMan();
                break;
            case GameState.SpawnMind:
                ManManager.Instance.SpawnMind();
                break;
            case GameState.GridCalculation:
                GridCalculator.Instance.GridCalculation();
                break;
            case GameState.CommenceMovement:
                Movement.Instance.CommenceMovement();
                break;
            case GameState.Liminality:
                Liminal.Instance.Liminality();
                break;
            default:
                throw new
ArgumentOutOfRangeException(nameof(newState), newState, null);

        }
    }
}



public enum GameState
{
    GenerateGrid = 0,
    SpawnMan = 1,
    SpawnMind = 2,
    GridCalculation = 3,
    CommenceMovement = 4,
    Liminality = 5,
}

