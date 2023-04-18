using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Liminal : MonoBehaviour
{
    public static Liminal Instance;
    private bool ienumeratorThing = false;


    void Awake()
    {
        Instance = this;
    }

    public void Liminality()
    {
        /*
        if (!ienumeratorThing)
        {
            StartCoroutine(waiter());
        }
        **/

        TimeKingdom.Instance.Invoke("TimeHasPassed", 0.5f);
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
