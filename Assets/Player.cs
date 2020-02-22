using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
  public int id;
  public int position = 0;
  public int balance = 1500;
  public int nGoPasses = 0;
  public int prisonDuration = 0;
  public bool surrendered = false;
  // Property[] properties = new Property[]();

  public Player(int id)
  {
    this.id = id;
    Debug.Log("Player " + id + " created.");
  }

  public void move(Tile[] board, int repetition = 1)
  {
    int dice1 = Random.Range(1, 6);
    int dice2 = Random.Range(1, 6);
    Debug.Log("Dice thrown: " + dice1 + " and " + dice2 + ".");
    int result = dice1 + dice2;
    if (prisonDuration == 0 || dice1 == dice2)
    {
      this.prisonDuration = 0;
      this.position = this.position + result;
      int nTiles = board.Length;
      if (this.position >= nTiles)
      {
        this.position = this.position % nTiles;
        this.crossGo();
      }
      board[this.position].landingAction();
    }
    else
    {
      int maxRepetitions = 3;
      if (repetition <= maxRepetitions)
      {
        this.move(board, repetition + 1);
      }
    }
  }

  public void crossGo()
  {
    Debug.Log("Crosses Go.");
    this.balance = this.balance + 400;
  }

  public bool isActive()
  {
    return balance > 0 && !this.surrendered;
  }
}
