using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Liminal : MonoBehaviour
{
    public static Liminal Instance;
    public bool goMode;
  //  private bool ienumeratorThing = false;


    void Awake()
    {
        Instance = this;

        goMode = false;
}

public void Liminality()
    {
        /*
        if (!ienumeratorThing)
        {
            StartCoroutine(waiter());
        }
        **/
        if (goMode == true)
        {
            TimeKingdom.Instance.Invoke("TimeHasPassed", 0.5f);
        }

        Debug.Log("wort");
    }
    /*
    private IEnumerator waiter()
    {
        ienumeratorThing = true;
        yield return new WaitForSeconds(1f);
        ienumeratorThing = false;
    }
    **/
}
