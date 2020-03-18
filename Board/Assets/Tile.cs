using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public abstract class Tile : MonoBehaviour
{
    public int owner;
    public int id = 0;




    public abstract void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board);
   
    public void buy(Player currentPlayer)
    {
        
        owner = currentPlayer.id;
        //currentPlayer.cards.Add(id); = 

    }

    public void upgrade(Player currentPlayer)
    {

    }

    public void mortgage(Player currentPlayer)
    {

    }
    public void sell(Player currentPlayer)
    {

    }
}
