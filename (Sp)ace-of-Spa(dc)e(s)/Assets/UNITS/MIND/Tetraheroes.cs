using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraheroes : BaseMind
{
    private List<BaseUnit> players;

    public override void interact(BaseUnit unit)
    {
        {
            if (unit.moners >= 1)
            {
                players.Add(unit);

                

                Debug.Log("Yippee!!!");
                unit.tetraNeed -= 1;
                unit.moners -= 1;
            }
        }
    }
}
