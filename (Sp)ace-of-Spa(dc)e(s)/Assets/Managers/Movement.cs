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
        GridBugMang.Instance.Reset();

        foreach(BaseMEAT patron in ManManager.Instance.patrons)
        {
            if (patron.IsReal == true)
            {
                patron.ManTileQualCheck();
            }
        }

        ManManager.Instance.Enter();

        GameManager.Instance.ChangeState(GameState.Liminality);

    }
}
