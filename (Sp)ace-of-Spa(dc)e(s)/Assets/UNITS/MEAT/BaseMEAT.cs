using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMEAT : BaseUnit
{
    public int tetraNeed, ballerNeed, exitNeed, moners;

    public void ManTimeUpdate()
    {
        this.exitNeed += 1;
    }



}
