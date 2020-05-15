using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cont : MonoBehaviour
{
    public GameObject box;
    public GameObject texty;
    public GameObject contBut;
    public bool confirmed = false;
    public bool run;
    public enum Type { draw, pay, roll, fu };
    public Type b;

    public GameObject cardPan;
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
    public Text own;



    public void Start()
    {
        box.SetActive(false); // or false                         
        enabled = false;
    }

    void OnDisable()
    {
        box.SetActive(false); // or false
        contBut.SetActive(false);
        confirmed = false;
        this.b = Type.fu;
    }

    void OnEnable()
    {
        confirmed = false;
        box.SetActive(true); // or false
        contBut.SetActive(true);
        cardPan.SetActive(false);
        if (run == false)
        {
            Time.timeScale = 1f;
            run = true;
        }

    }
    //requires text to be displayes as input, as well as context of continue box it is displaying
    public void SetText(string a, Type b)
    {
        texty.GetComponent<Text>().text = a;
        this.b = b;

        //if a player is paying another will display that tiles info
        if (b == Type.pay)
        {
            cardPan.SetActive(true);
            cardTitle.GetComponent<Text>().text = Game.board[Game.currentPlayer.getPosition()].title;
            rent.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].curPrice;
            numh.GetComponent<Text>().text = "" + Game.board[Game.currentPlayer.getPosition()].numHouses;
            cost.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].originalPrice;
            nohouses.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].noHouse;
            oneh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].oneHouse;
            twoh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].twoHouse;
            treeh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].threeHouse;
            fourh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].fourHouse;
            oneho.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].oneHotel;
            own.GetComponent<Text>().text = "Player " + Game.board[Game.currentPlayer.getPosition()].owner;

            backCol.GetComponent<Image>().color = TileStreet.colorFromString(Game.board[Game.currentPlayer.getPosition()].color);
            backCol.SetActive(true);
            if (Game.board[Game.currentPlayer.getPosition()].color == "Station" || Game.board[Game.currentPlayer.getPosition()].color == "Utilities")
            {
                nohouses.GetComponent<Text>().text = "";
            }

        }
    }


    public void ContButPress()
    {
        confirmed = true;
        cardPan.SetActive(false);
    }

    public int UpgradeCost(int i)
    {
        int holder = 0;
        if (Game.board[i].color == "Brown" || Game.board[i].color == "Blue")
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
