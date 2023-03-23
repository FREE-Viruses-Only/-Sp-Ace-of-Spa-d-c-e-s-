using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : Tile
{
    [SerializeField] private Color baseColor, offsetColor;

    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        rend.color = isOffset ? offsetColor : baseColor;
    }
}
