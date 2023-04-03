using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKingdom : MonoBehaviour
{
    public static TimeKingdom Instance;

    [SerializeField] private int time;

    void Awake()
    {
        Instance = this;
    }

    public void TimeHasPassed()
    {
        time += 1;
        Men.Instance.OneMomentHasPassed(time);
    }

    public void OnButtonPress()
    {
        TimeHasPassed();
    }

}
