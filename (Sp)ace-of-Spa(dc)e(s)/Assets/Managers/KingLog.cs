using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class KingLog : MonoBehaviour
{
    public static KingLog Instance;
    [SerializeField] private TextMeshProUGUI Logs;

    private static int logCount = 0;
    private static string transmogrify = "Booting";

    private static List<string> theeseOnes = new List<string>();
    private static string bigString;
    private static int depth = -20;
    
    static Dictionary<int, string> homestuck = new Dictionary<int, string> { };

    //  private bool ienumeratorThing = false;
    // MAKE DICTIONARY FOR LOG

    void Awake()
    {
        Instance = this;
        Log(transmogrify);
    }

    public void Log(string msg)
    {
        //  Logs.text = Logs.text + "\n \n ************************************* \n" + msg;
        transmogrify =  $"\n [{logCount}] ************************************* \n" + msg;

        homestuck.Add(logCount, transmogrify);


        logCount += 1;

        depth++;

        POST();
    }
    /*
    public void Log(string msg)
    {
        //  Logs.text = Logs.text + "\n \n ************************************* \n" + msg;
        homestuck.Add(logCount, transmogrify);

        transmogrify = msg;

        logCount += 1;

        depth++;

        POST();
    }
    */
    public void POST()
    {
        theeseOnes.Clear();
        Logs.text = "";
        for (int i = 0; i < 20; i++)
        {
            if (i >= homestuck.Count)
            {
                break;
            }
            if (depth >= 0)
            {
                theeseOnes.Add(homestuck[i + depth].ToString());

            }
            else
            {
                theeseOnes.Add(homestuck[i].ToString());
            }

        }

        foreach (string entry in theeseOnes)
        {
            Logs.text += entry;
        }

        if (Logs.textInfo.lineCount > 200)
        {

        }
    }
}
