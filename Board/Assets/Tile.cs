using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public abstract class Tile
{
    public int owner;
    public int id;
    public Tile(int id)
  {
    this.id = id;
  }

    public void landingAction(Player currentPlayer)
    {
        Debug.Log("Player " + this.id + "landed on tile " + id + ".");
    }

    public void buy(Player currentPlayer)
    {
        
        owner = currentPlayer.id; 
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
