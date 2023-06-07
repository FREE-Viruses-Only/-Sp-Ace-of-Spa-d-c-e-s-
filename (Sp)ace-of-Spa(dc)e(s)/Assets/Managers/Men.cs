using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Men : MonoBehaviour
{
    public static Men Instance;

    [SerializeField] private GameObject selectedMeatObject, display, tileObject, tileUnitObject, timeObject;
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

    public RectTransform stanelRT;
    public bool isStanelDropped;
    public Vector2 stanelTargetCoordinates;
    public Vector2 stanelHome;
    public float stanelDistance;
    public GameObject stanel;
    public GameObject stanelTxt;
    [SerializeField] private TextMeshProUGUI stanelTxtForever;

    [SerializeField] private TextMeshProUGUI stanelTxtSometimes;

    public bool timeIsReal;
    public GameObject timeSwitchSwitch;
    public Image timeMage;

    public bool explodeMode;
    public GameObject explodeButon;
    public Image explimage;
    
    [SerializeField] private TextMeshProUGUI timeDiplay;

    // public var tempColor = image.color;

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

        stanelHome = stanel.GetComponent<RectTransform>().anchoredPosition;
        stanelTargetCoordinates = new Vector2(stanelRT.anchoredPosition.x, stanelHome.y);

        menuBits.Add(MenuOpen);
        menuBits.Add(menMan);
        menuBits.Add(menBaller);
        menuBits.Add(menTetra);
        menuBits.Add(menWall);

        timeMage = timeSwitchSwitch.GetComponent<Image>();
        var tempColor = timeMage.color;

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
          //  tileUnitObject.SetActive(false);
            return;
        }

        tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        tileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            stanelTxtSometimes.text = tile.OccupiedUnit.UnitName;
            //tileUnitObject.SetActive(true);
        }
        else
        {
            stanelTxtSometimes.text = "~  ~  ~";
            //tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedHero(BaseMEAT meat)
    {
        if (meat == null)
        {
            selectedMeatObject.SetActive(false);
            display.SetActive(false);
            stanelTxtForever.text = "...";
            return;
        }

        selectedMeatObject.GetComponentInChildren<Text>().text = meat.UnitName;
        selectedMeatObject.SetActive(true);

        display.GetComponentInChildren<Image>().sprite = meat.GetComponent<SpriteRenderer>().sprite;
        display.SetActive(true);

        stanelTxtForever.text = $"MONERS : {meat.moners}  " +
            $"|  EXIT NEED : {meat.exitNeed}\nTetra Need : {meat.tetraNeed}  |  " +
            $"Baller Need : {meat.ballerNeed}\nGump Mod : {meat.gumpMod}  |  " +
            $"Dex Mod : {meat.dexMod}";
    }

    public void OneMomentHasPassed(int time)
    {
        timeDiplay.text = time.ToString();
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

    public void googleShowMeThisGuysStats()
    {
        if (isStanelDropped)
        {
            stanelTargetCoordinates = stanelHome;
            isStanelDropped = false;
        }
        else
        {
            stanelTargetCoordinates = new Vector2(-345.0f, stanelHome.y);
            isStanelDropped = true;
        }
    }

    public void OPENTHECABINET()
    {
        foreach (GameObject bit in menuBits)
        {
            bit.SetActive(true);
        }
    }

    public void flipTimeSwitch()
    {
        var tempColor = timeMage.color;

        if (timeIsReal)
        {
       //     timeSwitchSwitch.GetComponentInChildren<Image>().color.a = 1f;

            tempColor.a = 1f;
            timeMage.color = tempColor;

            Debug.Log("PUNK");

            timeIsReal = false;


            Liminal.Instance.goMode = false;
        }
        else
        {
            //          timeSwitchSwitch.image.color.alpha = 100;

            tempColor.a = 0f;
            timeMage.color = tempColor;

            timeIsReal = true;

            TimeKingdom.Instance.Invoke("TimeHasPassed", 0.5f);

            Liminal.Instance.goMode = true;
        }

    }

    public void explodeModeButonPress()
    {
        var tempColor = explimage.color;

        if (!explodeMode)
        {
            tempColor.a = 1f;
            explodeButon.color = tempColor;

            explodeMode = true
        }
        else
        {
            tempColor.a = 0f;
            explimage
        }
    }



    void Update()
    {
        // lerps dropdown towards the coordinate we want it to
        dropdownRT.anchoredPosition = Vector2.Lerp(dropdownRT.anchoredPosition, new Vector2(dropdownRT.anchoredPosition.x, dropdownTargetCoordinates.y), Time.deltaTime * 8f);
        logRT.anchoredPosition = Vector2.Lerp(logRT.anchoredPosition, new Vector2(logTargetCoordinates.x, logRT.anchoredPosition.y), Time.deltaTime * 8f);
        stanelRT.anchoredPosition = Vector2.Lerp(stanelRT.anchoredPosition, new Vector2(stanelTargetCoordinates.x, stanelRT.anchoredPosition.y), Time.deltaTime * 8f);

    }

}
