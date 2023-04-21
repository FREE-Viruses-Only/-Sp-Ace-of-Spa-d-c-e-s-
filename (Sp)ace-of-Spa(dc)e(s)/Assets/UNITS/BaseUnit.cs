using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit: MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;

    public int tetraNeed, ballerNeed, exitNeed, moners;

    public virtual void interact(BaseUnit unit)
    {
        Debug.Log("Woah Now");
    }
}
