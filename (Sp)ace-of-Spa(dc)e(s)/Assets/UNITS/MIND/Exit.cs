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

    [SerializeField] private Tile TheWayOut;

    private void Bunk()
    {
        range = GridBugMang.Instance.width * 2;
    }

    public void ExitAdvertize()
    {
        this.Exitage = 10000;

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
                        Vector2 nextTilePosition = new Vector2(this.transform.position.x + x, this.transform.position.y + y);
                        ChangeExitQuality(nextTilePosition, (Mathf.Pow(0.7f, distanceFromCenter) * 1000));

                    }


                }
            }
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
