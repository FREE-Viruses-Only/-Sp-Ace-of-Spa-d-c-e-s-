using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BaseMEAT : BaseUnit
{
    public int RoulletteWheel;

    [SerializeField] public int card;

    public int ThataWay;
//    public int Ceiling;

    public Tile THISONE;

    public List<Tile> TileOptions;
    public List<int> QualBarriers;

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
        Vector3 locVal = this.transform.position;
        RoulletteWheel = 0;

        /*
        int Nqual = 0;
        int Ewunk = 0;
        int Swunk = 0;
        int Wwunk = 0;
        **/

        TileOptions = new List<Tile>();
        TileOptions.Clear();
        QualBarriers = new List<int>();
        QualBarriers.Clear();

        Tile North = Grab(new Vector2(locVal.x, locVal.y + 1));
        Tile East = Grab(new Vector2(locVal.x + 1, locVal.y));
        Tile South = Grab(new Vector2(locVal.x, locVal.y - 1));
        Tile West = Grab(new Vector2(locVal.x - 1, locVal.y));
        Tile Here = Grab(new Vector2(locVal.x, locVal.y));

        Listificate(North);
        Listificate(East);
        Listificate(South);
        Listificate(West);
        Listificate(Here);

        /*
        TileOptions.Add(North);
        TileOptions.Add(East);
        TileOptions.Add(South);
        TileOptions.Add(West);
        TileOptions.Add(Here);
        **/


        foreach(Tile CurrentOption in TileOptions)
        {
            if (CurrentOption != null && CurrentOption.absoluteUniteracctivity == false) // && (CurrentOption.Walkable == true || CurrentOption.transform.position == this.transform.position))
            {
                CurrentOption.quality = 0;

                if (this.ballerNeed <= 0)
                {
                    this.ballerNeed = 0;
                }

                if (this.tetraNeed <= 0)
                {
                    this.tetraNeed = 0;
                }

                if (this.moners <= 0)
                {
                    this.moners = 0;
                    this.tetraNeed = 0;
                    this.ballerNeed = 0;
                    this.exitNeed += 10;
                }

                CurrentOption.quality = ((this.tetraNeed * (CurrentOption.Tetrahedronage ^ 2))) + ((this.ballerNeed * (CurrentOption.Ballerage ^ 2))) + ((this.exitNeed * (CurrentOption.Exitage ^ 2)));

                RoulletteWheel += CurrentOption.quality;
    //            CurrentOption.quality;
                QualBarriers.Add(CurrentOption.quality);
            }
        }
        

        /*
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
        **/


//        int stack = North.quality + West.quality + South.quality + East.quality;
         
        ThataWay = Random.Range(0, RoulletteWheel);

        int Ceiling = 0;

        foreach(Tile CurrentOption in TileOptions)
        {
            Ceiling += CurrentOption.quality;
            if(ThataWay <= Ceiling)
            {
                THISONE = CurrentOption;
                break;
            }
        }

        /*
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
        **/
        if (THISONE != null)
        {
            THISONE.SetUnit(this);
        }

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

    public void Listificate(Tile CurrentTile)
    {
        if (CurrentTile != null)
        {
            TileOptions.Add(CurrentTile);
        }
    }

    public void ManMove()
    {
        
    }

}
