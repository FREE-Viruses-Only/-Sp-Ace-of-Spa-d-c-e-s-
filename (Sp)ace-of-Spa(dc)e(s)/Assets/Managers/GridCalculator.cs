using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GridCalculator : MonoBehaviour
{

    public static GridCalculator Instance;


    void Awake()
    {
        Instance = this;
    }

    public void GridCalculation()
    {
//        for (int i = 0; i < tiles.length; i++)
        {
//            tiles.Where(t => t.quality != 0).OrderBy(t => Random.value).First().Value;

        }

        GameManager.Instance.ChangeState(GameState.CommenceMovement);

    }
}
