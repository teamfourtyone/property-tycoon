using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFreeParking : Tile
{
  public int balance;
  public TileFreeParking(int id) : base(id)
  {

  }

  public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
  {
    Debug.Log("Player " + currentPlayer.id + " landed on free parking tile " + this.id + ".");
    currentPlayer.balance += this.balance;
    this.balance = 0;
    nextPlayer.move(board);
  }

}
