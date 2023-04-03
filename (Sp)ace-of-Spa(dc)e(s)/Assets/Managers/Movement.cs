using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;


    void Awake()
    {
        Instance = this;
    }

    public void CommenceMovement()
    {
        {

        }

        GameManager.Instance.ChangeState(GameState.Liminality);

    }
}
