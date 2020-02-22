using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Static class, for general game-play mechanisms / data.
public class Game : MonoBehaviour
{
  ArrayList pile1 = new ArrayList<Card>();
  ArrayList pile2 = new ArrayList<Card>();

  void Start()
  {
    this.pile1 = this.pile1.shuffle();
    this.pile2 = this.pile2.shuffle();
  }

  void Update()
  {
    // visual update of moves
  }

  void move(Player player)
  {
    player.position = player.position + this.diceRoll();
    if (player.position >= Board.length)
    {
      player.position = player.position % Board.length;
      Player.crossGo();

    }
    Board[player.position].landingAction(player);
  }

  void diceRoll(int repetition = 1)
  {
    Random rnd = new Random();
    int dice1 = rnd.Next(1, 7);
    int dice2 = rnd.Next(1, 7);
    int result = dice1 + dice2;
    maxRepetitions = 3;
    if (dice1 == dice2)
    {
      Player.prisoned = false;
      if (repetition <= maxRepetitions)
      {
        result = result + this.diceRoll(repetition + 1);
      }
    }
  }

}
