using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

// For general game-play mechanisms / data.
public class Game : MonoBehaviour
{
    public static Tile[] board;
    public static Card[] pile1 = new Card[20];
    public static Card[] pile2 = new Card[20];
    public static Player[] players;
    double time = 0;
    double step = 0;
    public static Player currentPlayer;
    public static Player nextPlayer;
    public int lastd1; // "d" = "dice" ?
    public int lastd2; // "d" = "dice" ?

    void Start()
    {
        Debug.Log("Game initialization starting.");

        // Read configuration from CSV file.
        var reader = new StreamReader(@"PropertyTycoonBoardData.csv");
        List<string> tiletype = new List<string>();
        List<string> space = new List<string>();
        List<string> color = new List<string>();
        List<string> cost = new List<string>();
        List<string> noHouse = new List<string>();
        List<string> oneHouse = new List<string>();
        List<string> twoHouse = new List<string>();
        List<string> threeHouse = new List<string>();
        List<string> fourHouse = new List<string>();
        List<string> oneHotel = new List<string>();
        while (!reader.EndOfStream)
        {
            string[] line = reader.ReadLine().Split(',');
            space.Add(line[1]);
            tiletype.Add(line[5]);
            color.Add(line[3]);
            cost.Add(line[7]);
            noHouse.Add(line[8]);
            oneHouse.Add(line[10]);
            twoHouse.Add(line[11]);
            threeHouse.Add(line[12]);
            fourHouse.Add(line[13]);
            oneHotel.Add(line[14]);
        }

        // Initialize board.
        int nTiles = 4 * 10;
        Game.board = new Tile[nTiles];
        for (int i = 0; i < nTiles; i++)
        {
            if (tiletype[i] == "Yes" /* can be bought */)
            {
                Game.board[i] = new TileStreet(i, space[i], color[i], cost[i], noHouse[i], oneHouse[i], twoHouse[i], threeHouse[i], fourHouse[i], oneHotel[i]);
            }
            else
            {
                Game.board[i] = new TileGo(i);
            }
        }

        // Initialize players.
        int nPlayers = 6;
        Game.players = new Player[nPlayers];
        for (int i = 0; i < nPlayers; i++)
        {
            Game.players[i] = new Player(i);
            Game.players[i].setPosition(0);
        }

        Game.pile1 = Card.shuffle(Game.pile1);
        Game.pile2 = Card.shuffle(Game.pile2);

        Debug.Log("Game starting.");
        Debug.Log("board length  " + Game.board.Length);
        players[0].move();
    }

    void Update()
    {
        if (step > 0.2)
        {
            // Perform token animations.
            for (int playerId = 0; playerId < players.Length; playerId++)
            {
                Player player = Game.players[playerId];
                if (player.getAnimatedPosition() != player.getPosition())
                {
                    player.setAnimatedPosition((player.getAnimatedPosition() + 1) % Game.board.Length);
                    GameObject playerToken = GameObject.Find("player" + (playerId + 1));
                    Vector3 coordinates = Game.CoordinatesFromPosition(player.getAnimatedPosition());
                    playerToken.transform.position = new Vector3(
                      (float)(coordinates.x + playerId * 0.2),
                      playerToken.transform.position.y,
                      (float)(coordinates.z + playerId * 0.2)
                    );
                    if (player.getAnimatedPosition() == player.getPosition())
                    {
                        Game.board[player.getPosition()].landingAction();
                    }
                }
            }
            // Check whether the game is over.
            int nActivePlayers = Game.players
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

    public static Vector3 CoordinatesFromPosition(int position, float xAdd = 0, float yAdd = 0, float zAdd = 0)
    {
        float y = 0f + yAdd;
        int rowLength = Game.board.Length / 4;
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