using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make this an abstract class, create inheriting child classes for Go Tile, Street Tile, etc.
public abstract class Tile : MonoBehaviour
{
  public int owner;
  public int id;
  public int numHouses;
  public bool mortgaged;
    public string colour;
  public int originalPrice;
  public int curPrice; // what landing players will pay
  public int mortPrice; // price of property when mortgaged


  public GameObject tileObject;
  public GameObject textObject;


  public abstract void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board);

  public void buy(Player currentPlayer)
  {
    Debug.Log(currentPlayer + " buying " + id);
    Game.Instance.board[Game.Instance.curplayer.getPosition()].owner = Game.Instance.curplayer.id;
    Game.Instance.curplayer.cards.Add(Game.Instance.board[Game.Instance.curplayer.getPosition()].id); //holds ids
    for (int i = 0; i < Game.Instance.curplayer.cards.Count; i++)
    {
      Debug.Log("printing cards" + currentPlayer.cards[i].GetType());
    }
  }

  public void Auctbuy(Player currentPlayer)
  {
    Debug.Log(currentPlayer.id + " buying from Auction card:" + Game.Instance.curplayer.getPosition());
    Game.Instance.board[Game.Instance.curplayer.getPosition()].owner = currentPlayer.id;
    Game.Instance.curplayer.cards.Add(Game.Instance.board[Game.Instance.curplayer.getPosition()].id); //holds ids
    for (int i = 0; i < Game.Instance.curplayer.cards.Count; i++)
    {
      Debug.Log("printing cards" + currentPlayer.cards[i]);
    }

  }
  public void upgrade()
  {
    Game.Instance.board[Game.Instance.curplayer.getPosition()].numHouses += 1;

  }

  public int mortgage()
  {
    return originalPrice - mortPrice;
  }
  public void sell(Player currentPlayer)
  {

  }

}
