using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public abstract class Tile : MonoBehaviour
{
    public string title; //
    public int curPrice; // what landing players will pay
    public int numHouses = 0;
    public string originalPrice; //
    public string noHouse;//
    public string oneHouse;//
    public string twoHouse;//
    public string threeHouse;//
    public string fourHouse;//
    public string oneHotel;//

    public int owner;
    public int id;

    public bool mortgaged = false;
    public string color; //


    public GameObject tileObject;
    public GameObject textObject;


    public abstract void landingAction();

    //assigns tile to current player, ajusts their balance and variables accordingly
    public void buy()
    {
        Game.board[Game.currentPlayer.getPosition()].ResetPrice();
        Debug.Log(Game.currentPlayer + " buying " + id);
        Game.currentPlayer.balance -= int.Parse(Game.board[Game.currentPlayer.getPosition()].originalPrice);
        Game.board[Game.currentPlayer.getPosition()].owner = Game.currentPlayer.id;
        Game.currentPlayer.cards.Add(Game.board[Game.currentPlayer.getPosition()].id); //holds ids
        for (int i = 0; i < Game.currentPlayer.cards.Count; i++)
        {
            Debug.Log("printing cards" + Game.currentPlayer.cards[i].GetType());
        }
    }

    //assigns tile to the auction winner, ajusts their balance and variables accordingly
    public void Auctbuy(int otherId, int winBid)
    {
        Game.board[Game.currentPlayer.getPosition()].ResetPrice();
        Debug.Log(Game.players[otherId].id + " buying from Auction card:" + Game.currentPlayer.getPosition());
        Game.board[Game.currentPlayer.getPosition()].owner = Game.players[otherId].id;
        Game.players[otherId].balance -= winBid;
        Game.players[otherId].cards.Add(Game.board[Game.currentPlayer.getPosition()].id);


    }
    //when called uses the variable of the tile class to calculate what the current rent of the tile should be
    public void ResetPrice()
    {
        if (color != "Station")
        {
            if (color != "Utilities")
            {
                if (mortgaged == false)
                {
                    if (numHouses == 0)
                    {

                        curPrice = int.Parse(noHouse);

                    }
                    if (numHouses == 1)
                    {
                        curPrice = int.Parse(oneHouse);
                    }
                    if (numHouses == 2)
                    {
                        curPrice = int.Parse(twoHouse);
                    }
                    if (numHouses == 3)
                    {
                        curPrice = int.Parse(threeHouse);
                    }
                    if (numHouses == 4)
                    {
                        curPrice = int.Parse(fourHouse);
                    }
                    if (numHouses == 5)
                    {
                        curPrice = int.Parse(oneHotel);
                    }
                }
                else
                {
                    curPrice = 0;
                }
            }
            else
            {
                int hold = 0;
                bool sameOwn = false;
                int sameid = 99;
                for (int i = 0; i < Game.board.Length; i++)
                {
                    if (Game.board[i].color == "Utilities" && Game.board[i].owner == owner && Game.board[i].id != id && Game.board[i].owner != 99)
                    {
                        sameOwn = true;
                    }
                }

                if (sameOwn)
                {
                    curPrice = 10 * (Game.currentPlayer.dice1 + Game.currentPlayer.dice1);
                }
                else
                {
                    curPrice = 4 * (Game.currentPlayer.dice1 + Game.currentPlayer.dice1);
                }


            }
        }

        else
        {
            int hold = 0;
            for (int i = 0; i < Game.board.Length; i++)
            {
                if (Game.board[i].color == "Station")
                {
                    if (Game.board[i].owner == owner && Game.board[i].id != id && Game.board[i].owner != 99)
                    {
                        hold++;
                    }
                }
            }
            if (hold == 1)
            {
                curPrice = 25;
            }
            if (hold == 2)
            {
                curPrice = 50;
            }
            if (hold == 3)
            {
                curPrice = 100;
            }
            if (hold == 4)
            {
                curPrice = 200;
            }
        }
    }


}

