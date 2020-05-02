using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDraw : Tile
{

    public GameObject go;
    public static Player nextPlayerr;
    public static Tile[] boardy;

    public TileDraw(int i)
    {
        id = i;
    }

    public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
    {
        Debug.Log("Player " + currentPlayer.id + " landed on card draw tile " + this.id + ".");
        nextPlayerr = nextPlayer;
        boardy = board;
        go = GameObject.Find("GameController");
        go.GetComponent<Cont>().enabled = true;
        go.GetComponent<Cont>().SetText("Player " + currentPlayer.id + " Landed On Card Draw Tile" , Cont.Type.draw);
        // 
    }
    public void nextp()
    {
        nextPlayerr.move(boardy);
    }

    void Update()
    {
        //Debug.Log("CURRENT CHOICEE" + GameObject.Find("GameController").GetComponent<Buy>().choiceMade);
        if (go.GetComponent<Cont>().confirmed == true && go.GetComponent<Cont>().b == Cont.Type.draw)
        {
            go.GetComponent<Cont>().enabled = false;
            Card.draw();
            nextp();
        }
    }
}
