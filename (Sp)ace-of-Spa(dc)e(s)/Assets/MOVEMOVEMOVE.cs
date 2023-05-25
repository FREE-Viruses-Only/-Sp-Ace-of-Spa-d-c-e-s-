using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMOVEMOVE : MonoBehaviour
{
    private float initX, initY;

    [SerializeField] private GameObject grobject;

    private RectTransform rectShk;

    void Start()
    {
        initX = grobject.GetComponent<RectTransform>().anchoredPosition.x;
        initY = grobject.GetComponent<RectTransform>().anchoredPosition.y;

        rectShk = grobject.GetComponent<RectTransform>();

        //    initX = this.transform.X;
        //    initY = this.transform.Y;
    }
    // Update is called once per frame
    void Update()
    {
        rectShk.anchoredPosition = new Vector2 (rectShk.anchoredPosition.x, initX + Random.Range(-0.1f, 0.1f));
        rectShk.anchoredPosition = new Vector2(initX + Random.Range(-0.2f, 0.0f), rectShk.anchoredPosition.y);

    }
}
