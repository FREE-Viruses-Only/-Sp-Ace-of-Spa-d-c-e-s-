using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraheroes : BaseMind
{
    private List<BaseUnit> players = new List<BaseUnit>();
    private List<BaseUnit> gamers = new List<BaseUnit>();
    private BaseUnit winner;
    private BaseUnit leader;
    private int moneyPile;
    private int bets;

    public int BigestCard;

    private int raise;

    public int spindex;

    private List<int> cards;


    public override void interact(BaseUnit man)
    {
        {

            if (man.moners >= 1)
            {
                players.Add(man);

                Debug.Log("I love TETRAHEROES!!!");
                man.moners -= 1;

                moneyPile += 1;
            }
        }
    }

    public override void update()
    {
        cards = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        int index = 0;

        gamers.Clear();


        foreach(BaseUnit player in players)
        {
            int dealt = Random.Range(0, cards.Count);

            player.card = cards[dealt];
            cards.RemoveAt(index);
            index++;

            player.loser = false;

            gamers.Add(player);
        }

        if (players.Count == 1)
        {
            Debug.Log("Im Alone!");
            players[0].moners += 1;
        }

        if (players.Count >= 2)
        {
            Debug.Log($"Now we are starting a game with {players.Count} players");

            winner = null;

            foreach (BaseUnit speaker in gamers)
            {
                Debug.Log($"Hallo Im {speaker.UnitName}");
            }

            
            {
                foreach (BaseUnit gamer in gamers)
                {
                    Debug.Log($"{moneyPile} moners are in the money pile");

                    gamer.gumption = Random.Range(0, 16);

                    raise = gamer.card - gamer.gumption;

                    Debug.Log($"{gamer.UnitName} here and my gumption is {gamer.gumption}, my card is {gamer.card}, and Im going to raise {raise} moners");

                    if (raise > 0 && gamer.moners >= raise && gamer.loser == false)
                    {
                        moneyPile += raise;
                        gamer.moners -= raise;

                        int windex = 0;

                        foreach (BaseUnit opponent in gamers)
                        {
                            if (opponent != gamer && opponent.loser == false)
                            {
                                opponent.gumption = Random.Range(0, 16);

                                if (opponent.card - opponent.gumption >= 0 && opponent.moners >= raise)
                                {
                                    moneyPile += raise;
                                    opponent.moners -= raise;

                                    Debug.Log($"{opponent.UnitName} will match with {raise} moners");

                                }
                                else
                                {
                                    Debug.Log($"{opponent.UnitName} FOLDS!!!");

                                    opponent.loser = true;

                                    //gamers.RemoveAt(windex);///////////////////////////////////////////////////////////////////////////////////////////////////////
                                }


                            }

                            windex++;

                        }
                    }

                }

                BigestCard = 0;

                spindex = 0;

                leader = null;

                Debug.Log($"Ok now everyone show your cards \n Biggest card value atm: {BigestCard} \n Spindex atm: {spindex}");


                foreach (BaseUnit maybeWinner in gamers)
                {
                    if (maybeWinner.loser == false)
                    {
                        Debug.Log($"{maybeWinner.UnitName} reaveals a {maybeWinner.card}");

                        if (maybeWinner.card > BigestCard)
                        {
                            BigestCard = maybeWinner.card;

                            if (spindex != 0)
                            {
                                Debug.Log($"{gamers[spindex - 1].UnitName} is out! {maybeWinner.card}");

                                gamers[spindex - 1].loser = true;

                                //gamers.RemoveAt(spindex-1);///////////////////////////////////////////////////////////////////////////////////////////////////////
                            }

                            leader = maybeWinner;

                            Debug.Log($"{leader.UnitName} is now leading with a {maybeWinner.card} \n The bigest card is now {BigestCard}");

                        }
                        else
                        {
                            Debug.Log($"{maybeWinner.UnitName} Loses \nTheir card: {maybeWinner.card}");

                            gamers[spindex].loser = true;

                            //gamers.RemoveAt(spindex);///////////////////////////////////////////////////////////////////////////////////////////////////////

                        }
                    }
                    

                    spindex++;
                }

                spindex = 0;

                foreach (BaseUnit kicking in gamers)
                {
                    if (kicking.loser == false)
                    {
                        winner = kicking;
                    }
                    spindex++;
                }
                /*
                if (gamers.Count <= 1)
                {
                    winner = gamers[0];
                }*/
            }

            if (winner != null)
            {
                Debug.Log($"{winner.UnitName} WINNNNNNSSSSSSSSSSSSSS!!! \n {moneyPile} moners for this guy!");
                winner.moners += moneyPile;

            }

        }
        players.Clear();



        moneyPile = 0;
        
    }
}
