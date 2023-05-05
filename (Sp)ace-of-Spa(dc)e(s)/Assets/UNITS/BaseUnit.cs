using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit: MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;
    public bool IsReal;
    public bool loser;
    public Vector2 Home;

    public int card, shotCount, shotsMade;

    public int gumption, dexterity;
    public int gumpMod, dexMod;

    public int tetraNeed, ballerNeed, exitNeed, moners;

    public int itemsHeld;

    public List<BaseUnit> inventory = new List<BaseUnit>();

    public BaseUnit holder;

    public virtual void interact(BaseUnit unit)
    {
        Debug.Log("Woah Now");
    }

    public virtual void goHome()
    {
        this.transform.position = Home;
        this.IsReal = false;
    }

    public virtual void update()
    {

    }

    public void checkDex()
    {
        this.dexterity = Random.Range(0, 100) * dexMod;
    }
}
