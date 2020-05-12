﻿using UnityEngine;
using TMPro;

public class TileStreet : Tile
{

  public int choice;
  public GameObject go;

  public GameObject canvas;
  public GameObject rollPan;

  public static Player landedPlayer;
  public static Player nextPlayerr;
  public static Tile[] boardy;
  public bool ready;
  int tempid;
  public string name;
  public string color;
  private GameObject tileColorObject;
  public TileStreet(int i, string name, string color, Tile[] board)
  {
    this.name = name;
    this.color = color;
    numHouses = 0;
    mortgaged = false;
    owner = 0;
    id = i;

    // Base Tile Object
    tileObject = GameObject.Instantiate(GameObject.Find("TileStreetDummy"));
    tileObject.transform.position = Game.CoordinatesFromPosition(board, id);
    tileObject.transform.Rotate(0, (id / 10) * 90, 0, Space.World);
    // Text
    textObject = tileObject.transform.GetChild(0).gameObject;
    var textMesh = textObject.GetComponent<TextMeshPro>();
    textMesh.text = name;
    // Color
    tileColorObject = tileObject.transform.GetChild(1).gameObject;
    tileColorObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    tileColorObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", TileStreet.colorFromString(color));
  }

  public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
  {

    Time.timeScale = 0f;
    go = GameObject.Find("GameController");
    tempid = id;
    landedPlayer = currentPlayer;
    nextPlayerr = nextPlayer;
    boardy = board;


    Debug.Log("Landed on tile " + id + ".");

    if (owner != 0)
    {
      landedPlayer = currentPlayer;
      if (currentPlayer.id == owner)
      {
        Debug.Log("upgrade?");
        go.GetComponent<Choice>().enabled = true;

      }
      else
      {
        go.GetComponent<Cont>().enabled = true;
        go.GetComponent<Cont>().SetText("Player " + currentPlayer.id + " Pay Player " + owner + " \n £" + curPrice, Cont.Type.pay);
        currentPlayer.balance -= this.curPrice;
        Debug.Log("player " + currentPlayer.id + " paying player " + owner);
        //if (currentPlayer.balance <= 0)
        //{
        //START MORTGAGE TODO
        //    mortgage(currentPlayer);
        // }


      }
    }
    else
    {
      //BUY
      Debug.Log("choice 3");
      choice = 3;
      Debug.Log("run buy");
      go.GetComponent<Buy>().enabled = true;
      go.GetComponent<Auction>().enabled = true;
      go.GetComponent<Auction>().enabled = false;

    }

    Debug.Log("card count player " + currentPlayer.id + ": " + currentPlayer.cards.Count);

  }

  public void nextp()
  {
    Time.timeScale = 0f;
    rollPan.SetActive(true);
    rollPan.GetComponent<Roll>().enabled = true;
    nextPlayerr.move(boardy);

  }



  void Update()
  {
    //Debug.Log("CURRENT CHOICEE" + GameObject.Find("GameController").GetComponent<Buy>().choiceMade);
    if (go.GetComponent<Choice>().choiceMa == 3)
    {
      go.GetComponent<Choice>().enabled = false;
      Debug.Log("skipping");
      Time.timeScale = 1f;
      nextp();
      Debug.Log("shouldnt be auctioning");
    }
    if (go.GetComponent<Choice>().choiceMa == 4)
    {
      upgrade();
      go.GetComponent<Choice>().enabled = false;
      Debug.Log("upgrading");
      Time.timeScale = 1f;
      nextp();
    }

    if (go.GetComponent<Auction>().finished == true)
    {
      Auctbuy(go.GetComponent<Auction>().auctWin);
      go.GetComponent<Auction>().enabled = false;
      choice = 0;
      Debug.Log("returns auction");
      Time.timeScale = 1f;
      nextp();
    }

    if (go.GetComponent<Buy>().choiceMade == 1)
    {
      Debug.Log("choise 1 has been accepted");

      go.GetComponent<Buy>().enabled = false;
      go.GetComponent<Auction>().enabled = true;

      //buy(go.GetComponent<Auction>().auctWin);
      choice = 0;
      Debug.Log("returns choise 1");
    }
    if (go.GetComponent<Buy>().choiceMade == 2)
    {
      Debug.Log("returns choise 2 has been accepted");
      //buy
      // buy(landedPlayer);

      Game.Instance.board[Game.Instance.curplayer.getPosition()].buy(Game.Instance.curplayer);

      go.GetComponent<Buy>().enabled = false;
      choice = 0;
      Debug.Log("returns choise 2");
      Time.timeScale = 1f;
      Debug.Log("update board  " + boardy.Length);
      nextp();
    }
    if (go.GetComponent<Cont>().confirmed == true && go.GetComponent<Cont>().b == Cont.Type.pay)
    {
      go.GetComponent<Cont>().enabled = false;
      Time.timeScale = 1f;
      nextp();

    }

  }

  private static Color colorFromString(string s)
  {
    switch (s)
    {
      case "Blue":
        return Color.cyan;
      case "Brown":
        return new Color(0.545f, 0.271f, 0.075f, 1f);
      case "Green":
        return Color.green;
      case "Deep blue":
        return Color.blue;
      case "Orange":
        return new Color(1f, 0.549f, 0f, 1f);
      case "Purple":
        return new Color(0.502f, 0f, 0.502f, 1f);
      case "Red":
        return Color.red;
      case "White":
        return Color.white;
      case "Yellow":
        return Color.yellow;
      case "Utilities":
        return Color.gray;
      case "Station":
        return Color.black;
      default:
        return Color.gray;
    }
  }
}


