
using UnityEngine;

public class TileStreet : Tile
{
  public string colour;
  public int numHouses;
  public bool mortgaged;
  public int orininalPrice;
  public int curPrice;

  public TileStreet()
  {
    numHouses = 0;
    mortgaged = false;
    owner = 0;
  }

  public void landingAction(Player currentPlayer)
  {
    Debug.Log("Landed on tile " + id + ".");
    if (owner != 0)
    {

      if (currentPlayer.id == owner)
      {
        Debug.Log("upgrade?");
        bool upgrade = true;
        if (upgrade)
        {
          //popup yes/no
          upgrade(currentPlayer);
        }
      }
      else
      {
        currentPlayer.balance -= this.curPrice;
        if (currentPlayer.balance <= 0)
        {
          //START MORTGAGE
          mortgage(currentPlayer);
        }
      }
    }
    else
    {
      //BUY
      buy(currentPlayer);
    }
  }
}