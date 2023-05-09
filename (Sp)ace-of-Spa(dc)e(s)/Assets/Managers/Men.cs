using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Men : MonoBehaviour
{
    public static Men Instance;

    [SerializeField] private GameObject selectedMeatObject, tileObject, tileUnitObject, timeObject;
    public RectTransform dropdownRT;
    public bool isDropped;
    public Vector2 dropdownTargetCoordinates;
    public Vector2 dropdownHome;
    public float dropdownDistance;
    public GameObject DropdownMenu;

    void Awake()
    {
        Instance = this;
        dropdownHome = DropdownMenu.transform.position;
        dropdownTargetCoordinates = new Vector2(dropdownHome.x, dropdownRT.anchoredPosition.y);
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
        else
        {
            tileUnitObject.GetComponentInChildren<Text>().text = "Empty!";
            tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedHero(BaseMEAT meat)
    {
        if (meat == null)
        {
            selectedMeatObject.SetActive(false);
            return;
        }

        selectedMeatObject.GetComponentInChildren<Text>().text = meat.UnitName;
        selectedMeatObject.SetActive(true);
    }

    public void OneMomentHasPassed(int time)
    {
        timeObject.GetComponentInChildren<Text>().text = time.ToString();
    }

    public void DropThisShitDown()
    {
        if (isDropped)
        {
            // plus 225 for some reason
            // sets coordinate for the dropdown to goto
            dropdownTargetCoordinates = dropdownHome;
            isDropped = false;
        }
        else
        {
            dropdownTargetCoordinates = new Vector2(dropdownHome.x,-92.515f);
            isDropped = true;
        }
    }

    void Update()
    {
        // lerps dropdown towards the coordinate we want it to
        dropdownRT.anchoredPosition = Vector2.Lerp(dropdownRT.anchoredPosition, new Vector2(dropdownRT.anchoredPosition.x, dropdownTargetCoordinates.y), Time.deltaTime * 8f);
    }

}
