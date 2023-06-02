using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMind : BaseUnit
{
    //   public Tile RecieverGame;

    public int range;
    private Dictionary<Vector2, float> tilesInHand = new Dictionary<Vector2, float>();
    private Dictionary<Vector2, float> tileOUT = new Dictionary<Vector2, float>();
    private List<Vector2> keyList = new List<Vector2>();
    public Tile thisTile;
    public Tile propogaeTile;

    private void Bunk() 
    {
        range = 3;
            //GridBugMang.Instance.width*2;
    }


   // private Dictionary<Vector2, float> stinkingTiles = new Dictionary<Vector2, float>();

    public void AdvertizeEngague()
    {
        if(this.UnitName == "Mad Max Balling Road")
        {
            if (this.OccupiedTile != null)
            {
                this.OccupiedTile.Ballerage = 1000;

                //           for(int i = 0; )
                //         RecieverGame = GridBugMang.Instance.GetTileAtPosition(new Vector2(this.OccupiedTile.transform.position.x + 1, this.OccupiedTile.transform.position.y));
                //       RecieverGame.Ballerage = 100;

                Bunk();
/*
                for (int x = -range; x <= range; x++)
                {
                    for (int y = -range; y <= range; y++)
                    {
                        float distanceFromCenter = Mathf.Abs(x) + Mathf.Abs(y);
                        if (distanceFromCenter <= range)
                        {
                            Vector2 nextTilePosition = new Vector2(this.OccupiedTile.transform.position.x + x, this.OccupiedTile.transform.position.y + y);
                            ChangeBasketballQuality(nextTilePosition, (Mathf.Pow(0.3f, distanceFromCenter) * 1000));

                        }
                    }
                }
*/
                if(!tilesInHand.ContainsKey(this.OccupiedTile.transform.position))
                {
                    tilesInHand.Add(this.OccupiedTile.transform.position, 0);
                    this.OccupiedTile.proporpisagate = true;
                }

                tileOUT = tilesInHand;
                keyList = new List<Vector2>(this.tilesInHand.Keys);

                if(tilesInHand.Count > 0)
                {
                    for (int i = 1; i <= range; i++)
                    {

                        keyList = new List<Vector2>(this.tilesInHand.Keys);

                        for (int index = 0; index < keyList.Count; index++)
                        {
                            
                            {
                                propogaeTile = GridBugMang.Instance.GetTileAtPosition(keyList[index]);

                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x + 1, keyList[index].y));

                                if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                                {
                                    tilesInHand.Add(thisTile.transform.position, i);
                                    ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                }

                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x - 1, keyList[index].y));

                                if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                                {
                                    tilesInHand.Add(thisTile.transform.position, i);
                                    ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                }

                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x, keyList[index].y + 1));

                                if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                                {
                                    tilesInHand.Add(thisTile.transform.position, i);
                                    ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                }

                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x, keyList[index].y - 1));

                                if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                                {
                                    tilesInHand.Add(thisTile.transform.position, i);
                                    ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                }



                                /*
                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(imLookinAtThisOneRightNow.Key.x - 1, imLookinAtThisOneRightNow.Key.y));
                                if (thisTile != null && thisTile.isWalkable)
                                {
                                    if (thisTile.proporpisagate == false)
                                    {
                                        tilesInHand.Add(thisTile.transform.position, i);
                                        ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                        thisTile.proporpisagate = true;
                                    }
                                }

                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(imLookinAtThisOneRightNow.Key.x, imLookinAtThisOneRightNow.Key.y + 1));
                                if (thisTile != null && thisTile.isWalkable)
                                {
                                    if (thisTile.proporpisagate == false)
                                    {
                                        tilesInHand.Add(thisTile.transform.position, i);
                                        ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                        thisTile.proporpisagate = true;
                                    }
                                }

                                thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(imLookinAtThisOneRightNow.Key.x + 1, imLookinAtThisOneRightNow.Key.y - 1));
                                if (thisTile != null && thisTile.isWalkable)
                                {
                                    if (thisTile.proporpisagate == false)
                                    {
                                        tilesInHand.Add(thisTile.transform.position, i);
                                        ChangeBasketballQuality(thisTile.transform.position, propogaeTile.Ballerage / 2);
                                        thisTile.proporpisagate = true;
                                    }
                                }
                                */
                            }

                        }
                    }
                
                }

                foreach (KeyValuePair<Vector2, float> CLEAR in tilesInHand)
                {
                    GridBugMang.Instance.GetTileAtPosition(CLEAR.Key).proporpisagate = false;
                }
                
                tilesInHand.Clear();
            }

        }

        if (this.UnitName == "Tetraheroes")
        {
            if (this.OccupiedTile != null)
            {
                this.OccupiedTile.Tetrahedronage = 1000;

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
                            ChangeTetQuality(nextTilePosition, (Mathf.Pow(0.3f, distanceFromCenter) * 1000));

                        }


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
