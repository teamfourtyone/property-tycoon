using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDraw : Tile
{
  public TileDraw(int id) : base(id)
  {

  }
  public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
  {
    Debug.Log("Player " + currentPlayer.id + " landed on card draw tile " + this.id + ".");
    Card.draw();
    nextPlayer.move(board);
  }

}
