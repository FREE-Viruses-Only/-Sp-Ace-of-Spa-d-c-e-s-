using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMind : BaseUnit
{
    //   public Tile RecieverGame;

    public int range;

    private void Bunk() 
    {
           range = GridBugMang.Instance.width;
    }


    private Dictionary<Vector2, float> stinkingTiles = new Dictionary<Vector2, float>();

    public void AdvertizeEngague()
    {
        if(this.UnitName == "Mad Max Balling Road")
        {
            this.OccupiedTile.Ballerage = 100;

            //           for(int i = 0; )
            //         RecieverGame = GridBugMang.Instance.GetTileAtPosition(new Vector2(this.OccupiedTile.transform.position.x + 1, this.OccupiedTile.transform.position.y));
            //       RecieverGame.Ballerage = 100;

            Bunk();

            for (int x = -range; x <= range; x++)
            {
                for (int y = -range; y <= range; y++)
                {
                    float distanceFromCenter = Mathf.Abs(x) + Mathf.Abs(y);
                    if (distanceFromCenter <= range)
                    {
                        Vector2 nextTilePosition = new Vector2(this.OccupiedTile.transform.position.x + x, this.OccupiedTile.transform.position.y + y);
                        ChangeBasketballQuality(nextTilePosition, (Mathf.Pow(0.7f, distanceFromCenter) * 100));

                    }


                }
            }


        }

        if (this.UnitName == "Tetraheroes")
        {
            this.OccupiedTile.Tetrahedronage = 100;

            //           for(int i = 0; )
            //         RecieverGame = GridBugMang.Instance.GetTileAtPosition(new Vector2(this.OccupiedTile.transform.position.x + 1, this.OccupiedTile.transform.position.y));
            //       RecieverGame.Ballerage = 100;

            Bunk();

            for (int x = -range; x <= range; x++)
            {
                for (int y = -range; y <= range; y++)
                {
                    float distanceFromCenter = Mathf.Abs(x) + Mathf.Abs(y);
                    if (distanceFromCenter <= range)
                    {
                        Vector2 nextTilePosition = new Vector2(this.OccupiedTile.transform.position.x + x, this.OccupiedTile.transform.position.y + y);
                        ChangeTetQuality(nextTilePosition, (Mathf.Pow(0.7f, distanceFromCenter) * 100));

                    }


                }
            }
        }
    }



    private void ChangeBasketballQuality(Vector2 gridPosition, float changeBy)
    {

        Tile TileInQuestion = GridBugMang.Instance.GetTileAtPosition(gridPosition);
        if (TileInQuestion != null)
        {
            TileInQuestion.Ballerage += (int)changeBy;
        }

    }

    private void ChangeTetQuality(Vector2 gridPosition, float changeBy)
    {

        Tile TileInQuestion = GridBugMang.Instance.GetTileAtPosition(gridPosition);
        if (TileInQuestion != null)
        {
            TileInQuestion.Tetrahedronage += (int)changeBy;
        }

    }

}
