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
            
            
                foreach(BaseMind Machine in ManManager.Instance.machines)
                {
                    Machine.AdvertizeEngague();
                }


              

        GameManager.Instance.ChangeState(GameState.CommenceMovement);
    

    }
}
