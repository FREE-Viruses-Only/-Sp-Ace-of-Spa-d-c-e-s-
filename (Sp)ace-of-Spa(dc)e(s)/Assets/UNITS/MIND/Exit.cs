using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Tile
{
    public static Exit Instance;

    void Awake()
    {
        Instance = this;
    }

    public int range;

    private Dictionary<Vector2, float> tilesInHand = new Dictionary<Vector2, float>();
    private Dictionary<Vector2, float> tileOUT = new Dictionary<Vector2, float>();
    private List<Vector2> keyList = new List<Vector2>();
    private Tile thisTile;
    private Tile propogaeTile;
    [SerializeField] private Tile TheWayOut;

    private void Bunk()
    {
        range = GridBugMang.Instance.width * 3;
    }

    public void ExitAdvertize()
    {
        this.Exitage = 10000;

        //           for(int i = 0; )
        //         RecieverGame = GridBugMang.Instance.GetTileAtPosition(new Vector2(this.OccupiedTile.transform.position.x + 1, this.OccupiedTile.transform.position.y));
        //       RecieverGame.Ballerage = 100;

        Bunk();



            if (!tilesInHand.ContainsKey(this.transform.position))
            {
                tilesInHand.Add(this.transform.position, 0);
            }

            //  tileOUT = tilesInHand;
            // keyList = new List<Vector2>(this.tilesInHand.Keys);

            if (tilesInHand.Count > 0)
            {
                for (int i = 1; i <= range; i++)
                {

                    keyList = new List<Vector2>(this.tilesInHand.Keys);

                    for (int index = 0; index < keyList.Count; index++)
                    {


                    propogaeTile = GridBugMang.Instance.GetTileAtPosition(keyList[index]);

                    thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x + 1, keyList[index].y));

                    if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                    {
                        tilesInHand.Add(thisTile.transform.position, i);
                        thisTile.Exitage = 1000 / i+1;
                    }
                    thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x - 1, keyList[index].y));

                    if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                    {
                        tilesInHand.Add(thisTile.transform.position, i);
                        thisTile.Exitage = 1000 / i + 1;
                    }
                    thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x, keyList[index].y + 1));

                    if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                    {
                        tilesInHand.Add(thisTile.transform.position, i);
                        thisTile.Exitage = 1000 / i + 1;
                    }
                    thisTile = GridBugMang.Instance.GetTileAtPosition(new Vector2(keyList[index].x, keyList[index].y - 1));

                    if (thisTile != null && thisTile.isWalkable && !tilesInHand.ContainsKey(thisTile.transform.position))
                    {
                        tilesInHand.Add(thisTile.transform.position, i);
                        thisTile.Exitage = 1000 / i + 1;
                    }



                }
            }

            

            foreach (KeyValuePair<Vector2, float> CLEAR in tilesInHand)
            {
                GridBugMang.Instance.GetTileAtPosition(CLEAR.Key).proporpisagate = false;
            }

            tilesInHand.Clear();
        }





        /*

            for (int x = -range; x <= range; x++)
            {
                for (int y = -range; y <= range; y++)
                {
                    float distanceFromCenter = Mathf.Abs(x) + Mathf.Abs(y);
                    if (distanceFromCenter <= range)
                    {
                        Vector2 nextTilePosition = new Vector2(this.transform.position.x + x, this.transform.position.y + y);
                        ChangeExitQuality(nextTilePosition, (Mathf.Pow(0.85f, distanceFromCenter) * 1000));

                    }


                }
            }
        */
    }

    private void ChangeExitQuality(Vector2 gridPosition, float changeBy)
    {

        Tile TileInQuestion = GridBugMang.Instance.GetTileAtPosition(gridPosition);
        if (TileInQuestion != null)
        {
            TileInQuestion.Exitage += (int)changeBy;
        }

    }


}
