using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDraw : Tile
{
  public TileDraw(int id) : base(id)
  {

  }
  public new void landingAction(Player currentPlayer)
  {
    Card.draw();
  }

}
