using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTool : BaseUnit
{
    public override void interact(BaseUnit man)
    {
        man.inventory.Add(this);
        this.holder = man;

        man.itemsHeld++;

        this.transform.position = new Vector2(man.Home.x, man.Home.y + itemsHeld);

    }

    public virtual void use()
    {
        Debug.Log($"What the actual fuck do I do with {this.UnitName}");
    }

}
