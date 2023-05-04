using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : BaseMind
{
    private List<BaseUnit> players = new List<BaseUnit>();
    private List<BaseUnit> gamers = new List<BaseUnit>();
    private BaseUnit winner;
    private BaseUnit ldr;
    private int moneyPile, winnings;
    private int bets;

 //   public int BigestCard;

 //   private int raise;

    public int spindex;

    public override void interact(BaseUnit man)
    {
        {

            if (man.moners >= 1)
            {
                players.Add(man);

                Debug.Log("I love Slam-m!!!");
                man.moners -= 1;

                moneyPile += 1;
            }
        }
    }

    public override void update()
    {
        if(players.Count == 1)
        {
            ldr = players[0];

            Debug.Log($"My name is {ldr.UnitName} and here I go!");

            ldr.shotCount = 0;
            ldr.shotsMade = 0;


            for (int i = 0; i < 6; i++)
            {
                ldr.dexterity = Random.Range(0, 100);

                ldr.shotCount += 1;

                Debug.Log($"I shoot my {ldr.shotCount} ball!!!");

                if (ldr.dexterity >= 70)
                {
                    ldr.shotsMade += 1;
                    Debug.Log("BWAAAAAAAA!!!!!");
                }
            }

            winnings = moneyPile * (shotsMade / (shotCount - 2));

            Debug.Log($"I just won {winnings} bazillion moners!!");

            ldr.moners += winnings;

            moneyPile = 0;
            shotCount = 0;
            shotsMade = 0;
        }

        if(players.Count >= 2)
        {
            Debug.Log("This isnt implemented yet!!!");
        }
    }
}
