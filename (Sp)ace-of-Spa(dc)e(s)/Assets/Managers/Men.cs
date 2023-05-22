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

    public RectTransform logRT;
    public bool isLogDropped;
    public Vector2 logTargetCoordinates;
    public Vector2 logHome;
    public float logDistance;
    public GameObject Log;

    [SerializeField] private GameObject MenuOpen;
    [SerializeField] private GameObject menMan;
    [SerializeField] private GameObject menBaller;
    [SerializeField] private GameObject menTetra;
    [SerializeField] private GameObject menWall;

    private List<GameObject> menuBits = new List<GameObject>();


    void Awake()
    {
        Instance = this;
        dropdownHome = DropdownMenu.GetComponent<RectTransform>().anchoredPosition;
        dropdownTargetCoordinates = new Vector2(dropdownHome.x, dropdownRT.anchoredPosition.y);

        logHome = Log.GetComponent<RectTransform>().anchoredPosition;
        logTargetCoordinates = new Vector2(logRT.anchoredPosition.x, logHome.y);

        menuBits.Add(MenuOpen);
        menuBits.Add(menMan);
        menuBits.Add(menBaller);
        menuBits.Add(menTetra);
        menuBits.Add(menWall);

        foreach (GameObject bit in menuBits)
        {
            bit.SetActive(false);
        }
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

            foreach (GameObject bit in menuBits)
            {
                bit.SetActive(false);
            }

            // plus 225 for some reason
            // sets coordinate for the dropdown to goto
            dropdownTargetCoordinates = dropdownHome;
            isDropped = false;
        }
        else
        {
            dropdownTargetCoordinates = new Vector2(dropdownHome.x,-160.515f);
            isDropped = true;

            Men.Instance.Invoke("OPENTHECABINET", 1f);

        }
    }

    public void BringThisShitOver()
    {
        if (isLogDropped)
        {

            // plus 225 for some reason
            // sets coordinate for the dropdown to goto
            logTargetCoordinates = logHome;
            isLogDropped = false;
        }
        else
        {
            logTargetCoordinates = new Vector2(145.515f, logHome.y);
            isLogDropped = true;

         //   Men.Instance.Invoke("OPENTHECABINET", 1f);

        }
    }

    public void OPENTHECABINET()
    {
        foreach (GameObject bit in menuBits)
        {
            bit.SetActive(true);
        }
    }

    void Update()
    {
        // lerps dropdown towards the coordinate we want it to
        dropdownRT.anchoredPosition = Vector2.Lerp(dropdownRT.anchoredPosition, new Vector2(dropdownRT.anchoredPosition.x, dropdownTargetCoordinates.y), Time.deltaTime * 8f);
        logRT.anchoredPosition = Vector2.Lerp(logRT.anchoredPosition, new Vector2(logTargetCoordinates.x, logRT.anchoredPosition.y), Time.deltaTime * 8f);
    }

}
