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


    private void log(string msg)
    {
        KingLog.Instance.Log(msg);
    }

    public override void interact(BaseUnit man)
    {
        {

            if (man.moners >= 1)
            {
                players.Add(man);

                log("I love Slam-m!!!");
                man.moners -= 1;

                moneyPile += 1;
            }
        }
    }

    public override void update()
    {
        if (players.Count > 0)
        {
            if (players.Count == 1)
            {
                ldr = players[0];

                log($"My name is {ldr.UnitName} and here I go!");

                for (int i = 0; i < 6; i++)
                {
                    ldr.checkDex();

                    ldr.shotCount += 1;

                    log($"I shoot my {ldr.shotCount} ball!!!");

                    if (ldr.dexterity >= 70)
                    {
                        ldr.shotsMade += 1;
                        log("BWAAAAAAAA!!!!!");
                    }
                }

                winnings = moneyPile * (ldr.shotsMade / (ldr.shotCount - 4));
            }

            if (players.Count >= 2)
            {
                log("ITS TIME TO JUMP UP AND SLAM!!!");

                for (int i = 0; i < 6; i++)
                {
                    log($"ROUND {i + 1} GO");

                    foreach (BaseUnit baller in players)
                    {
                        baller.checkDex();

                        baller.shotCount += 1;

                        log($"{baller.UnitName} shoot thier {baller.shotCount} ball!!!");

                        if (baller.dexterity >= 70)
                        {
                            baller.shotsMade += 1;
                            log("BWAAAAAAAA!!!!!");
                        }

                        if (ldr == null || baller.shotsMade > ldr.shotsMade)
                        {
                            ldr = baller;

                            log($"{ldr.UnitName} is the new leader0!!");
                        }
                    }
                }

                winnings = moneyPile * (ldr.shotsMade / (ldr.shotCount - 4));
            }


            log($"{ldr.UnitName} just won {winnings} bazillion moners!!");

            ldr.moners += winnings;

            moneyPile = 0;

            foreach (BaseUnit man in players)
            {
                man.shotCount = 0;
                man.shotsMade = 0;
            }


            ldr = null;



            players.Clear();
        }
        
    }
}
