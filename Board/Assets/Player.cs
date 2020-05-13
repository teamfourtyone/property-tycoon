using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject rollPan;
  public int id;
  // Theoretical position (during an animation that is the position where the token is when the animation ends.)
  private int position = 0;
  // Temporary position during an animation, otherwise identical with theoretical position.
  private int animatedPosition;
  public int balance = 1500;
  public int nGoPasses = 0;
  public int prisonDuration = 0;
  public bool surrendered = false;

  // public ArrayList cards = new ArrayList();
  public List<int> cards = new List<int>();

  public int dice1;
  public int dice2;


  public Player(int id)
  {
    this.id = id;
    //    Instancee = this;
  }

  public void move(int repetition = 1)
  {
    Game.currentPlayer = this;
    Game.nextPlayer = Game.players[(this.id + 1) % Game.players.Length];
    //Time.timeScale = 0f;
    rollPan = GameObject.Find("RollPanel");
    this.dice1 = Random.Range(1, 6);
    this.dice2 = Random.Range(1, 6);
    //rollPan.SetActive(true);
    //rollPan.GetComponent<Roll>().enabled = true;
    // rollPan.GetComponent<Roll>().setDice(d1, d2);
    Debug.Log("Dice thrown: " + dice1 + " and " + dice2 + ".");
    int result = dice1 + dice2;
    if (prisonDuration == 0 || dice1 == dice2)
    {
      this.prisonDuration = 0;
      this.setPosition(this.position + result);
    }
    else
    {
      int maxRepetitions = 3;
      if (repetition <= maxRepetitions)
      {
        this.move(repetition + 1);
      }
    }
  }

  public int getId()
  {
    return this.id;
  }

  public int getPosition()
  {
    return this.position;
  }

  public void setPosition(int position)
  {
    if (position >= Game.board.Length)
    {
      this.crossGo();
    }
    // Debug.Log("position "+ position);
    // Debug.Log("board.Length " + board.Length);
    this.position = position % Game.board.Length;
  }
  public int getAnimatedPosition()
  {
    return this.animatedPosition;
  }
  public void setAnimatedPosition(int animatedPosition)
  {
    this.animatedPosition = animatedPosition;
  }

  public static double[] getXZ(int position)
  {
    int rowLength = Game.board.Length / 4;
    if (position < rowLength)
    {
      return new double[] { 0.5, position + 0.5 };
    }
    else if (position < rowLength * 2)
    {
      return new double[] { (position % rowLength) + 0.5, rowLength + 0.5 };
    }
    else if (position < rowLength * 3)
    {
      return new double[] { rowLength + 0.5, rowLength - (position % (rowLength * 2)) + 0.5 };
    }
    else
    {
      return new double[] { rowLength - (position % (rowLength * 3)) + 0.5, 0.5 };
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
