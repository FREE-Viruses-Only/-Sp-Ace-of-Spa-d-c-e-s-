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
        int stack = 0;
        int wunk = 0;
        int bunk = 0;
        int Nwunk = 0;
        int Ewunk = 0;
        int Swunk = 0;
        int Wwunk = 0;

        Tile North = Grab(new Vector2(sexVal.x, sexVal.y + 1));
        if (North != null && North.Walkable == true)
        {
            North.quality = 0;
            North.quality = (North.Tetrahedronage * this.tetraNeed) + (North.Ballerage * this.ballerNeed);

            stack += North.quality;
            Nwunk = North.quality;
        }


        Tile West = Grab(new Vector2(sexVal.x - 1, sexVal.y));
        if (West != null && West.Walkable == true)
        {
            West.quality = 0;
            West.quality = (West.Tetrahedronage * this.tetraNeed) + (West.Ballerage * this.ballerNeed);

            stack += West.quality;
            Wwunk = West.quality;
        }


        Tile South = Grab(new Vector2(sexVal.x, sexVal.y - 1));
        if(South != null && South.Walkable == true)
        {
            South.quality = 0;
            South.quality = (South.Tetrahedronage * this.tetraNeed) + (South.Ballerage * this.ballerNeed);

            stack += South.quality;
            Swunk = South.quality;
        }



        Tile East = Grab(new Vector2(sexVal.x + 1, sexVal.y));
        if (East != null && East.Walkable == true)
        {
            East.quality = 0;
            East.quality = (East.Tetrahedronage * this.tetraNeed) + (East.Ballerage * this.ballerNeed);

            stack += East.quality;
            Ewunk = East.quality;
        }



//        int stack = North.quality + West.quality + South.quality + East.quality;
        int flip = Random.Range(0, stack);

        

        if (flip < Nwunk)
        {
            THISONE = North;
        }   
        else if (flip >= Nwunk && flip < Nwunk + Wwunk)
        {
            THISONE = West;
        }
        else if (flip >= Nwunk + Wwunk && flip < Nwunk + Wwunk + Swunk)
        {
            THISONE = South;
        }
        else
        {
            THISONE = East;
        }

        THISONE.SetUnit(this);

        /*
        Debug.Log("Gen num" + flip);
        Debug.Log(stack);

        Debug.Log("North" + Nwunk);
        Debug.Log(Wwunk);
        Debug.Log(Swunk);
        Debug.Log(Ewunk);
        **/




        GridBugMang.Instance.Reset();

    }

    public void ManMove()
    {
        
    }

}
