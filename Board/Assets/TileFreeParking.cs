using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFreeParking : Tile
{
    public int balance;
    public TileFreeParking(int i)
    {
        id = i;
    }

    public override void landingAction()
    {
        Debug.Log("Player " + Game.currentPlayer.id + " landed on free parking tile " + this.id + ".");
        Game.currentPlayer.balance += this.balance;
        this.balance = 0;
        Game.nextPlayer.move();
    }

}
