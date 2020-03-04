using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGo : Tile
{
    public void landingAction(Player currentPlayer)
    {
        Debug.Log("Landed on tile " + id + ".");
        currentPlayer.crossGo();
    }
}


