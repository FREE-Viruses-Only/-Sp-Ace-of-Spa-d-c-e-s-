using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class KingLog : MonoBehaviour
{
    public static KingLog Instance;
    [SerializeField] private TextMeshProUGUI Logs;
    //  private bool ienumeratorThing = false;
    // MAKE DICTIONARY FOR LOG

    void Awake()
    {
        Instance = this;
    }

    public void Log(string msg)
    {
        Logs.text = Logs.text + "\n \n ************************************* \n" + msg;
    }

    public void Update()
    {
        if (Logs.textInfo.lineCount > 200)
        {

        }
    }
}
