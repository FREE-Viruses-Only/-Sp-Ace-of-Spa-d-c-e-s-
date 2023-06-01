using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GridCalculator : MonoBehaviour
{

    public static GridCalculator Instance;

    [SerializeField] private float QualCap;

    [SerializeField]
    private float testAddQAmount;

    [SerializeField]
    private float QFallOff;


    [SerializeField]
    private int testQRadius;

    [SerializeField]
    private float reduceAmount;

    void Awake()
    {
        Instance = this;
    }

    public void Advertize()
    {

        foreach (Tile tile in GridBugMang.Instance.tyles)
        {
            if (tile != null)
            {
                tile.Tetrahedronage = 0;
                tile.Ballerage = 0;
                tile.Exitage = 0;
                tile.proporpisagate = false;
            }
        }
                foreach(BaseMind Machine in ManManager.Instance.machines)
                {
                    Machine.AdvertizeEngague();
                }

        Exit.Instance.ExitAdvertize();


              

        GameManager.Instance.ChangeState(GameState.CommenceMovement);
    

    }
}
