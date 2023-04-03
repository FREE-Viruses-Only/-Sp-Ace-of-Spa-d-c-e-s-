using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit",menuName = "Scriptable Unit")]

public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public BaseUnit UnitPrefab;
    public bool Special;
}

public enum Faction
{
    MEAT = 0,
    MIND = 1,
    SPECIAL = 2,
}