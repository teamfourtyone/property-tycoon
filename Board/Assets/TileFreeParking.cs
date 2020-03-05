﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFreeParking : Tile
{
  public int balance;
  public TileFreeParking(int id) : base(id)
  {

  }

  public new void landingAction(Player currentPlayer)
  {
    Debug.Log("Landed on tile " + id + ".");
    currentPlayer.balance += this.balance;
    this.balance = 0;
  }

}
