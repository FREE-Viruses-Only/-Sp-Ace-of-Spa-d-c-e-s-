using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTOUCH : MonoBehaviour
{
    public static NOTOUCH Instance;

    public bool touching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Instance = this;
    }

    void OnMouseEnter()
    {
        touching = true;
    }

    void OnMouseExit()
    {
        touching = false;
    }
}
