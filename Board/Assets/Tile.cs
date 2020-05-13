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


  public abstract void landingAction();

  public void buy()
  {
    Debug.Log(Game.currentPlayer + " buying " + id);
    Game.board[Game.currentPlayer.getPosition()].owner = Game.currentPlayer.id;
    Game.currentPlayer.cards.Add(Game.board[Game.currentPlayer.getPosition()].id); //holds ids
    for (int i = 0; i < Game.currentPlayer.cards.Count; i++)
    {
      Debug.Log("printing cards" + Game.currentPlayer.cards[i].GetType());
    }
  }

  public void Auctbuy(Player player)
  {
    Debug.Log(player.id + " buying from Auction card:" + Game.currentPlayer.getPosition());
    Game.board[Game.currentPlayer.getPosition()].owner = player.id;
    Game.currentPlayer.cards.Add(Game.board[Game.currentPlayer.getPosition()].id); //holds ids
    for (int i = 0; i < Game.currentPlayer.cards.Count - 1; i++)
    {
      Debug.Log("printing cards" + player.cards[i]);
    }

  }
  public void upgrade()
  {
    Game.board[Game.currentPlayer.getPosition()].numHouses += 1;

  }

  public int mortgage()
  {
    return originalPrice - mortPrice;
  }
  public void sell()
  {

  }

}
