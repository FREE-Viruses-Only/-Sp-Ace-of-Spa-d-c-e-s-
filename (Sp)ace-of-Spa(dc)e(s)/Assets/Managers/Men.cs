using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Men : MonoBehaviour
{
    public static Men Instance;

    [SerializeField] private GameObject selectedMeatObject, tileObject, tileUnitObject;

    void Awake()
    {
        Instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            tileObject.SetActive(false);
            tileUnitObject.SetActive(false);
            return;
        }

        tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        tileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedHero (BaseHero hero)
    {
        if (hero == null)
        {
            selectedMeatObject.SetActive(false);
            return;
        }

        selectedMeatObject.GetComponentInChildren<Text>().text = selectedMeatObject.UnitName;
        selectedMeatObject.SetActive(true);
    }
}
