using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    void Start()
    {
        Debug.Log("Game initialization starting.");
        //Instance = this;
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
                case 15:
                case 25:
                case 35:
                    this.board[i] = new TileDraw(i);
                    break;
                case 10:
                    this.board[i] = new TileStreet(i);
                    // TODO: this.board[i] = new PrisonTile(i);
                    break;
                default:
                    this.board[i] = new TileStreet(i);
                    break;
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
               // Debug.Log("wrong1");
                if (player.getAnimatedPosition() != player.getPosition())
                {
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

}