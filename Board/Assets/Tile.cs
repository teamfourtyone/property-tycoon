using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public abstract class Tile: MonoBehaviour
{
    public int owner;
    public int id ;
    public int numHouses;

    public abstract void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board);
   
    public void buy(Player currentPlayer)
    {
        Debug.Log(currentPlayer);
        owner = currentPlayer.getId();
        currentPlayer.cards.Add(id);

    }

    public void upgrade()
    {
        numHouses += 1;
    }

    public void mortgage(Player currentPlayer)
    {

    }
    public void sell(Player currentPlayer)
    {

    }
    public void nextp(Player nextPlayer, Tile[] board)
    {
        nextPlayer.move(board);
    }
}
