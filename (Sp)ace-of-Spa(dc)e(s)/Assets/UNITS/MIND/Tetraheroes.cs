using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraheroes : BaseMind
{
    public override void interact(BaseUnit unit)
    {
        {
            Debug.Log("Yippee!!!");
            unit.tetraNeed -= 1;
            unit.moners -= 1;
        }
    }
}
