using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGo : Tile
{
  public TileGo(int id) : base(id)
  {

  }
  public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
  {
    Debug.Log("Player " + currentPlayer.id + " landed on Go.");
    currentPlayer.crossGo();
    nextPlayer.move(board);
  }
}


