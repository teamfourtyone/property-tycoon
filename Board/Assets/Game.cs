using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// For general game-play mechanisms / data.
public class Game : MonoBehaviour
{
  Tile[] board;
  Card[] pile1 = new Card[20];
  Card[] pile2 = new Card[20];
  Player[] players;

  void Start()
  {
    Debug.Log("Game initialization starting.");

    // Initialize board.
    int nTiles = 4 * 10;
    this.board = new Tile[nTiles];
    for (int i = 0; i < nTiles; i++)
    {
      switch (i)
      {
        case 0:
          this.board[i] = new Tile(i);
          // TODO: this.board[i] = new GoTile(i);
          break;
        case 10:
          this.board[i] = new Tile(i);
          // TODO: this.board[i] = new PrisonTile(i);
          break;
        default:
          this.board[i] = new Tile(i);
          break;
      }
    }

    // Initialize players.
    int nPlayers = 6;
    this.players = new Player[nPlayers];
    for (int i = 0; i < nPlayers; i++)
    {
      this.players[i] = new Player(i);
    }
    this.pile1 = Card.shuffle(this.pile1);
    this.pile2 = Card.shuffle(this.pile2);

    Debug.Log("Game starting.");
  }

  void Update()
  {
    for (int playerId = 0; playerId < players.Length; playerId++)
    {
      GameObject playerToken = GameObject.Find("player" + (playerId + 1));
      double[] XZ = players[playerId].getXZ(this.board);
      int scaleFactor = 2; // to adjust because the board size is 20 and not 10
      playerToken.transform.position = new Vector3(
        (float)(scaleFactor * (XZ[0] - 0.25 + playerId * 0.1)),
        0,
        (float)(scaleFactor * (XZ[1] - 0.25 + playerId * 0.1))
      );
    }
    int nActivePlayers = this.players
      .Where(p => p.isActive())
      .ToArray()
      .Length;
    if (nActivePlayers == 1)
    {
      this.End();
    }
  }

  void End()
  {

  }

}
