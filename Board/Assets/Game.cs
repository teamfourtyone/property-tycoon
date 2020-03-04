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
          this.board[i] = new TileGo(i);
          break;
        case 5:
        case 10:
          this.board[i] = new TileDraw();
        case 10:
          this.board[i] = new Tile(i);
          // TODO: this.board[i] = new PrisonTile(i);
          break;
        case 20:
          this.board[i] = new TileGo();
        default:
          this.board[i] = new TileStreet(i);
          break;
      }
    }

    // Initialize players.
    int nPlayers = 4;
    this.players = new Player[nPlayers];
    for (int i = 0; i < nPlayers; i++)
    {
      this.players[i] = new Player(i);
    }
    this.pile1 = Card.shuffle(this.pile1);
    this.pile2 = Card.shuffle(this.pile2);

    Debug.Log("Game starting.");
    this.players[0].move(board);
    this.players[1].move(board);
    this.players[2].move(board);
    this.players[0].move(board);
    this.players[1].move(board);
    this.players[0].move(board);
  }

  void Update()
  {
    for (int playerId = 0; playerId < players.Length; playerId++)
    {
      GameObject playerToken = GameObject.Find("player" + (playerId + 1));
      int[] XZ = players[playerId].getXZ(this.board);
      playerToken.transform.position = new Vector3(XZ[0], 0, XZ[1]);
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
