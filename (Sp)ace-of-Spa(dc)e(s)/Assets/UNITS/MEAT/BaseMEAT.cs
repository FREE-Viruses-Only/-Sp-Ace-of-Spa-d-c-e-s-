using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BaseMEAT : BaseUnit
{
    public int tetraNeed, ballerNeed, exitNeed, moners;

    public Tile THISONE;

    public void ManTimeUpdate()
    {
        this.exitNeed += 1;
    }

    private Tile Grab(Vector2 pog)
    {
        return GridBugMang.Instance.GetTileAtPosition(pog);
    }

    public void ManTileQualCheck()
    {
        Vector3 sexVal = this.transform.position;

        Tile North = Grab(new Vector2(sexVal.x, sexVal.y + 1));
        Tile East = Grab(new Vector2(sexVal.x + 1, sexVal.y));
        Tile South = Grab(new Vector2(sexVal.x, sexVal.y - 1));
        Tile West = Grab(new Vector2(sexVal.x - 1, sexVal.y));

        North.quality = 0;
        East.quality = 0;
        South.quality = 0;
        West.quality = 0;

        North.quality = (North.Tetrahedronage * this.tetraNeed) + (North.Ballerage * this.ballerNeed);
        East.quality = (East.Tetrahedronage * this.tetraNeed) + (East.Ballerage * this.ballerNeed);
        South.quality = (South.Tetrahedronage * this.tetraNeed) + (South.Ballerage * this.ballerNeed);
        West.quality = (West.Tetrahedronage * this.tetraNeed) + (West.Ballerage * this.ballerNeed);

        int stack = North.quality + East.quality + South.quality + West.quality;
        int This = Random.Range(0, stack);

        

        if (This < North.quality)
        {
            THISONE = North;
        }   
        else if (This < North.quality + East.quality)
        {
            THISONE = East;
        }
        else if (This < North.quality + East.quality + South.quality)
        {
            THISONE = South;
        }
        else
        {
            THISONE = West;
        }

        THISONE.SetUnit(this)

    }

    public void ManMove()
    {
        
    }

}
