﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDraw : Tile
{

    public GameObject go;

    public TileDraw(int i, string name)
    {
        id = i;
    }

    public override void landingAction()
    {
        Debug.Log("Player " + Game.currentPlayer.id + " landed on card draw tile " + this.id + ".");
        go = GameObject.Find("GameController");
        go.GetComponent<Cont>().enabled = true;
        go.GetComponent<Cont>().SetText("Player " + Game.currentPlayer.id + " Landed On Card Draw Tile", Cont.Type.draw);
        // 
    }
    public void nextp()
    {
        Game.nextPlayer.move();
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
