using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{

    public GameObject box;
    public GameObject texty;
    public GameObject noBut;
    public GameObject yesBut;
    public GameObject contBut;

    public int choiceMade = 0;
    public int tempChoiceMade = 0;
    public bool run = false;
    //GameObjects on visual card 
    public GameObject cardPan;
    public GameObject backCol;
    public Text cardTitle;
    public Text cost;
    public Text nohouses;
    public Text oneh;
    public Text twoh;
    public Text treeh;
    public Text fourh;
    public Text oneho;
    public Text upc;

    public void Start()
    {
        box.SetActive(false);
        enabled = false;
    }

    void OnDisable()
    {

        box.SetActive(false);
        noBut.SetActive(false);
        yesBut.SetActive(false);
        contBut.SetActive(false);
        backCol.SetActive(false);
        cardPan.SetActive(false);
        choiceMade = 0;
        tempChoiceMade = 0;
    }

    void OnEnable()
    {
        //makes panels visible
        choiceMade = 0;
        texty.GetComponent<Text>().text = "Would you like to buy this property?";
        box.SetActive(true); // or false
        noBut.SetActive(true);
        yesBut.SetActive(true);
        cardPan.SetActive(true);
        if (run == false)
        {
            Time.timeScale = 1f;
            run = true;

        }
        //sets up card on screen with information about the tile
        cardTitle.GetComponent<Text>().text = Game.board[Game.currentPlayer.getPosition()].title;
        cost.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].originalPrice;
        nohouses.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].noHouse;
        oneh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].oneHouse;
        twoh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].twoHouse;
        treeh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].threeHouse;
        fourh.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].fourHouse;
        oneho.GetComponent<Text>().text = "£" + Game.board[Game.currentPlayer.getPosition()].oneHotel;
        upc.GetComponent<Text>().text = "£" + UpgradeCost(Game.board[Game.currentPlayer.getPosition()].id);

        backCol.GetComponent<Image>().color = TileStreet.colorFromString(Game.board[Game.currentPlayer.getPosition()].color);
        backCol.SetActive(true);
        if (Game.board[Game.currentPlayer.getPosition()].color == "Station" || Game.board[Game.currentPlayer.getPosition()].color == "Utilities")
        {
            nohouses.GetComponent<Text>().text = "";
        }
    }
    //finds the costs of upgrading based on the colour 
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

    //called when "no" button pressed
    public void NoButPress()
    {
        texty.GetComponent<Text>().text = "To Auction!";
        tempChoiceMade = 1;

    }
    //called when "yes" button pressed, checks if player has enough money
    public void YesButPress()
    {
        if (Game.currentPlayer.balance >= int.Parse(Game.board[Game.currentPlayer.getPosition()].originalPrice))
        {
            texty.GetComponent<Text>().text = "Congratulations on Your Purchase";
            tempChoiceMade = 2;
        }
        else
        {
            texty.GetComponent<Text>().text = "You cant afford this :(";
        }
    }
    public void ContButPress()
    {
        choiceMade = tempChoiceMade;
    }

    //deactivates buttons after being pressed
    void Update()
    {
        if (tempChoiceMade >= 1)
        {
            contBut.SetActive(true);
            noBut.SetActive(false);
            yesBut.SetActive(false);
        }
    }


}
