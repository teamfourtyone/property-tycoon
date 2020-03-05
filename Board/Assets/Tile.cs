using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public class Tile
{
  public int id;
  public Tile(int id)
  {
    this.id = id;
  }

  public void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board) {
    Debug.Log("Player " + currentPlayer.id + " landed on tile " + this.id + ".");
    nextPlayer.move(board);
  }
}
