using UnityEngine;

public class TileStreet : Tile
{
  public string colour;
  public int numHouses;
  public bool mortgaged;
  public int orininalPrice;
  public int curPrice;

  public TileStreet(int id) : base(id)
  {
    numHouses = 0;
    mortgaged = false;
    owner = 0;
  }

  public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
  {
    Debug.Log("Player " + currentPlayer.id + " landed on street tile " + this.id + ".");
    if (owner != 0)
    {

      if (currentPlayer.id == owner)
      {
        Debug.Log("upgrade?");
        bool upgrade = true;
        if (upgrade)
        {
          //popup yes/no
          this.upgrade(currentPlayer);
        }
      }
      else
      {
        currentPlayer.balance -= this.curPrice;
        if (currentPlayer.balance <= 0)
        {
          //START MORTGAGE
          this.mortgage(currentPlayer);
        }
      }
    }
    else
    {
      //BUY
      this.buy(currentPlayer);
    }
    nextPlayer.move(board);
  }

  public void upgrade(Player player)
  {

  }
  public void mortgage(Player currentPlayer)
  {

  }
  public void buy(Player currentPlayer)
  {

  }
}