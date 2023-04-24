using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : BaseMind
{
    public override void interact(BaseUnit unit)
    {
        {
            Debug.Log("SLAM!!!");
            unit.ballerNeed -= 1;
            unit.moners -= 1;
        }
    }
}
