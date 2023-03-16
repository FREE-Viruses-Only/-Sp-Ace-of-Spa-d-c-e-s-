using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile: MonoBehaviour
{
    [SerializeField] private Color baseColor,offsetColor;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private GameObject highlight;

       public void Init(bool isOffset)
     {
         rend.color = isOffset ? baseColor : offsetColor;
  }




    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
