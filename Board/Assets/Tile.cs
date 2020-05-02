using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public abstract class Tile: MonoBehaviour
{
    public int owner;
    public int id ;
    public int numHouses;
    
    public abstract void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board);

    public void buy(Player currentPlayer)
    {
        Debug.Log(currentPlayer + " buying " + id);
        Game.Instance.board[Game.Instance.curplayer.getPosition()].owner = Game.Instance.curplayer.id;
        Game.Instance.curplayer.cards.Add(Game.Instance.board[Game.Instance.curplayer.getPosition()]);
        
    }

    public void Auctbuy(Player currentPlayer)
    {
        Debug.Log(currentPlayer.id + " buying from Auction card:" + Game.Instance.curplayer.getPosition());
        Game.Instance.board[Game.Instance.curplayer.getPosition()].owner = currentPlayer.id;
        currentPlayer.cards.Add(Game.Instance.board[Game.Instance.curplayer.getPosition()]);

    }
    public void upgrade()
    {
        Game.Instance.board[Game.Instance.curplayer.getPosition()].numHouses+= 1;
        
    }

    public void mortgage(Player currentPlayer)
    {

    }
    public void sell(Player currentPlayer)
    {

    }
    
}
