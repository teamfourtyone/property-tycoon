using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    public int cardId;
    public GameObject mo;
    public GameObject panel;
    public GameObject backCol;
    public Text cardTitle;
    public Text rent;
    public Text numh;
    public Text cost;
    public Text nohouses;
    public Text oneh;
    public Text twoh;
    public Text treeh;
    public Text fourh;
    public Text oneho;
    public Text upc;

    public Tile tile;

   
   

    public void SetText(string textString, int id, Tile tile)
    {
        myText.text = tile.title;
        cardId = tile.id;
        this.tile = tile;
     

    }

    public void onClick()
    {
        mo.SetActive(true);
        mo.GetComponent<Mort>().enabled = true;
        mo.GetComponent<Mort>().setParam(cardId);
        panel.SetActive(false);
    }
    public void OnMouseOver()
    {
        cardTitle.GetComponent<Text>().text = tile.title;
        rent.GetComponent<Text>().text = "£"+tile.curPrice;
        numh.GetComponent<Text>().text = ""+ tile.numHouses;
        cost.GetComponent<Text>().text = "£" + tile.originalPrice;
        nohouses.GetComponent<Text>().text = "£" + tile.noHouse;       
        oneh.GetComponent<Text>().text = "£" + tile.oneHouse;
        twoh.GetComponent<Text>().text = "£" + tile.twoHouse;
        treeh.GetComponent<Text>().text = "£" + tile.threeHouse;
        fourh.GetComponent<Text>().text = "£" + tile.fourHouse;
        oneho.GetComponent<Text>().text = "£" + tile.oneHotel;
         upc.GetComponent<Text>().text = "£" + UpgradeCost(cardId);
     
        backCol.GetComponent<Image>().color =  TileStreet.colorFromString(tile.color);
        backCol.SetActive(true);
    }

    public void OnMouseExit()
    {

        cardTitle.GetComponent<Text>().text = "";
        rent.GetComponent<Text>().text = "";
        numh.GetComponent<Text>().text = "";
        nohouses.GetComponent<Text>().text = "";
        cost.GetComponent<Text>().text = "";
        oneh.GetComponent<Text>().text = "";
        twoh.GetComponent<Text>().text = "";
        treeh.GetComponent<Text>().text = "";
        fourh.GetComponent<Text>().text = "";
        oneho.GetComponent<Text>().text = "";
         upc.GetComponent<Text>().text = "" ;
        backCol.SetActive(false);
    }
    
    public int UpgradeCost(int i)
    {
        int holder = 0;
        if(Game.board[i].color == "Brown" || Game.board[i].color == "Blue")
        {
            holder = 50;
        }
        if (Game.board[i].color == "Purple" || Game.board[i].color == "Orange")
        {
            holder = 100;
        }
        if (Game.board[i].color == "Red" || Game.board[i].color == "Yellow")
        {
            holder = 150;
        }
        if (Game.board[i].color == "Green" || Game.board[i].color == "Deep blue")
        {
            holder = 200;
        }
        return holder;
    }

}
