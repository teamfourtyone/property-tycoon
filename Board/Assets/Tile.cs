using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
  public int owner;
  public int id;
  public Tile(int id)
  {
    this.id = id;
  }

  public abstract void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board);
}
