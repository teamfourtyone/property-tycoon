using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

// For general game-play mechanisms / data.
public class Game : MonoBehaviour
{
  public static Game Instance;
  public Tile[] board;
  Card[] pile1 = new Card[20];
  Card[] pile2 = new Card[20];
  public Player[] players;
  double time = 0;
  double step = 0;
  public Player curplayer;
  public Player nextplayer;
  public int lastd1;
  public int lastd2;

  void Start()
  {
    Debug.Log("Game initialization starting.");


    var reader = new StreamReader(@"PropertyTycoonBoardData.csv");
    List<string> tiletype = new List<string>();
    List<string> space = new List<string>();
    List<string> color = new List<string>();
    while (!reader.EndOfStream)
    {
      string[] line = reader.ReadLine().Split(',');
      space.Add(line[1]);
      tiletype.Add(line[5]);
      color.Add(line[3]);
    }
    // Initialize board.
    int nTiles = 4 * 10;
    this.board = new Tile[nTiles];
    for (int i = 0; i < nTiles; i++)
    {
      if (tiletype[i] == "Yes" /* can be bought */)
      {
        board[i] = new TileStreet(i, space[i], color[i], board);
      }
      else
      {
        board[i] = new TileGo(i);
      }
    }

    // Initialize players.
    int nPlayers = 6;
    this.players = new Player[nPlayers];
    for (int i = 0; i < nPlayers; i++)
    {
      this.players[i] = new Player(i);
      this.players[i].setPosition(0, board);
    }
    this.pile1 = Card.shuffle(this.pile1);
    this.pile2 = Card.shuffle(this.pile2);

    Debug.Log("Game starting.");
    Debug.Log("board length  " + board.Length);
    players[0].move(board);
    /*
            //tile test
            Debug.Log("tiletest");
            Tile te = new TileStreet(1);
            te.landingAction(this.players[1], this.players[1], board);
            Debug.Log("tilefin");
            */
  }

  public Player[] RetPlayer()
  {
    return players;
  }

  void Update()
  {

    Instance = this;
    // Start();
    if (step > 0.2)
    {
      // Perform token animations.
      for (int playerId = 0; playerId < players.Length; playerId++)
      {
        Player player = players[playerId];


        Debug.Log("wrong1");
        if (player.getAnimatedPosition() != player.getPosition())
        {
          curplayer = player;
          nextplayer = players[(playerId + 1) % 6];
          // lastd1 = player.d1;
          // lastd2 = player.d2;
          // Debug.Log("moving?");
          //Debug.Log("mov board length  " + board.Length);
          player.setAnimatedPosition((player.getAnimatedPosition() + 1) % board.Length);
          GameObject playerToken = GameObject.Find("player" + (playerId + 1));
          double[] XZ = Player.getXZ(player.getAnimatedPosition(), this.board);
          int scaleFactor = 2; // to adjust because the board size is 20 and not 10
          playerToken.transform.position = new Vector3(
            (float)(scaleFactor * (XZ[0] - 0.25 + playerId * 0.1)),
            5,
            (float)(scaleFactor * (XZ[1] - 0.25 + playerId * 0.1))
          );
          //Debug.Log("wrong2");
          if (player.getAnimatedPosition() == player.getPosition())
          {
            //Debug.Log("wrong3");
            //curplayer = player;
            board[player.getPosition()].landingAction(player, players[(playerId + 1) % 6], board);
            // Debug.Log("thr board length  " + board.Length);
            //  Debug.Log("throw to landing");
          }
        }
      }
      // Check whether the game is over.
      int nActivePlayers = this.players
        .Where(p => p.isActive())
        .ToArray()
        .Length;
      if (nActivePlayers == 1)
      {
        this.End();
      }
      step = 0;
    }
    time = time + Time.deltaTime;
    step = step + Time.deltaTime;
  }

  void End()
  {

  }

  public static Vector3 CoordinatesFromPosition(Tile[] board, int position, float xAdd = 0, float yAdd = 0, float zAdd = 0)
  {
    float y = 0f + yAdd;
    int rowLength = board.Length / 4;
    int s = 2; // scale
    if (position < rowLength)
    {
      return new Vector3((float)0.5 * s + xAdd, y, (float)(position + 0.5) * s + yAdd);
    }
    else if (position < rowLength * 2)
    {
      return new Vector3((float)((position % rowLength) + 0.5) * s + xAdd, y, (float)(rowLength + 0.5) * s + yAdd);
    }
    else if (position < rowLength * 3)
    {
      return new Vector3((float)(rowLength + 0.5) * s + xAdd, y, (float)(rowLength - (position % (rowLength * 2)) + 0.5) * s + yAdd);
    }
    else
    {
      return new Vector3((float)(rowLength - (position % (rowLength * 3)) + 0.5) * s + xAdd, y, (float)0.5 * s + yAdd);
    }
  }

}