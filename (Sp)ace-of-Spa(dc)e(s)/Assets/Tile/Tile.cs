using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string TileName;
    public int Ballerage;
    public int Tetrahedronage;
    public int Exitage;

    [SerializeField] protected SpriteRenderer rend;
    [SerializeField] private GameObject highlight;
    [SerializeField] private bool isWalkable;
    [SerializeField] public bool absoluteUniteracctivity;

    public BaseUnit OccupiedUnit;
    public bool Walkable => isWalkable && OccupiedUnit == null;

    public int quality;

    public virtual void Init(int x, int y)
    {
        ;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        Men.Instance.ShowTileInfo(this);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
        Men.Instance.ShowTileInfo(null);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.Liminality) return;

        if (PawnerMan.Instance.pawnerTime)
        {
            SetUnit(PawnerMan.Instance.pawnThis);
            PawnerMan.Instance.pawnerTime = false;
            return;
        }

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.MEAT)
            {
                ManManager.Instance.SetSelectedMan((BaseMEAT)OccupiedUnit);
            }
            else
            {
                if (ManManager.Instance.SelectedMan != null)
                {
                    var enemy = (BaseMind)OccupiedUnit;
                    Destroy(enemy.gameObject);
                    ManManager.Instance.SetSelectedMan(null);
                }
            }
        }
        else
        {
            if (ManManager.Instance.SelectedMan != null && isWalkable)
            {
                SetUnit(ManManager.Instance.SelectedMan);
                ManManager.Instance.SetSelectedMan(null);
            }
        }
    }
    
    public void SetUnit (BaseUnit unit)
    {
        if (this == isWalkable || this.OccupiedUnit == unit)
        {
            if (unit.OccupiedTile != null)
            {
                unit.OccupiedTile.OccupiedUnit = null;
                unit.OccupiedTile.isWalkable = true;
            }

            this.isWalkable = false;
            unit.transform.position = transform.position;
            OccupiedUnit = unit;
            unit.OccupiedTile = this;

            if (unit.IsReal == false)
            {
                unit.IsReal = true;
            }
        }
        else if(this.TileName == "Exit")
        {
            unit.goHome();

        }
        else
        {
            this.OccupiedUnit.interact(unit);
        }

        
    }
}
