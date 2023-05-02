using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraheroes : BaseMind
{
    private List<BaseUnit> players;
    private List<BaseUnit> gamers;
    private BaseUnit winner;
    private int moneyPile;
    private int bets;

    private int raise;

    private List<int> cards;


    public override void interact(BaseUnit unit)
    {
        {
            if (unit.moners >= 1)
            {
                players.Add(unit);

                Debug.Log("I love TETRAHEROES!!!");
                unit.moners -= 1;

                moneyPile += 1;
            }
        }
    }

    public override void update()
    {
        cards = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        foreach(BaseUnit player in players)
        {
            int dealt = Random.Range(0, cards.Count);

            player.card = cards[dealt];
            cards.RemoveAt(dealt);

            gamers.Add(player);
        }

        if (players.Count = 1)
        {
            Debug.Log("Im Alone!");
        }

        if (players.Count >= 2)
        {
            Debug.Log($"Now we are starting a game with {players.Count} players");

            foreach (BaseUnit speaker in gamers)
            {
                Debug.Log($"Hallo Im {speaker.UnitName}");
            }

            while (winner = null)
            {
                foreach (BaseUnit gamer in gamers)
                {
                    Debug.Log($"{moneyPile} moners are in the money pile");

                    gamer.gumption = Random.Range(0, 16);

                    raise = gamer.card - gamer.gumption;

                    Debug.Log($"{gamer.UnitName} here and my gumption is {gamer.gumption}, my card is {gamer.card}, and Im going to raise {raise} moners");

                    if (raise > 0 && gamer.moners >= raise)
                    {
                        moneyPile += raise;
                        gamer.moners -= raise;

                        foreach (BaseUnit opponent in gamers)
                        {
                            if (opponent != gamer)
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
                                    gamers.remove[opponent];///////////////////////////////////////////////////////////////////////////////////////////////////////
                                }


                            }
                        }
                    }

                }

                int BigestCard = 0;

                foreach (BaseUnit maybeWinner in gamers)
                {
                    if (maybeWinner.card > BiggestCard)
                    {
                        BiggestCard = maybeWinner.card;
                        gamers.remove[prevNummer];///////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    prevNummer = maybeWinner;
                }

                if (gamers.Count <= 1)
                {
                    winner = gamers[0];
                }
            }
        }


        Debug.Log($"{winner.UnitName} WINNNNNNSSSSSSSSSSSSSS!!!");

        winner.moners += moneyPile;
        moneyPile = 0;
        
    }
}
