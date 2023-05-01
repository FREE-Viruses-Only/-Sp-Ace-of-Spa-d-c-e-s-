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

        foreach (BaseMEAT Man in ManManager.Instance.patrons)
        {
            Man.ManTimeUpdate();
        }

        foreach (BaseUnit thing in ManManager.Instance.patrons)
        {
            thing.update();
        }

        GameManager.Instance.ChangeState(GameState.Advertize);

    }

    public void OnButtonPress()
    {
        if (GameManager.Instance.GameState == GameState.Liminality)
        {
            TimeHasPassed();
        }

    }

}
