using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManManager : MonoBehaviour
{
    public static UnitManager Instance;

    void Awake()
    {
        Instance = this;
    }
}
