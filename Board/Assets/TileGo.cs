using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGo : Tile
{
    public TileGo(int i)
    {
        id = i;
    }
    public override void landingAction()
    {
        Debug.Log("Player " + Game.currentPlayer.id + " landed on Go.");
        Game.currentPlayer.crossGo();
        Game.nextPlayer.move();
    }
}


