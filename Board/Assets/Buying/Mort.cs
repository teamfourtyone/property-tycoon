using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mort : MonoBehaviour
{

    public GameObject box;
    public GameObject texty;
    public GameObject mortBut;
    public GameObject sellBut;
    public GameObject contBut;
    public GameObject upgradeBut;
    public GameObject firstSellBut;

    public int choiceMade = 0;
    public int tempChoiceMade = 0;
    public bool run = false;
    public int id = 0;
    public int numHouse;
    public string colour;
    public bool ownAll;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    void OnDisable()
    {
 
        box.SetActive(false); 
        enabled = false;

        choiceMade = 0;
        tempChoiceMade = 0;
    }

    public void setParam(int id)
    {
        this.id = id;

        for (int i = 0; i < Game.Instance.board.Length; i++)
        {
            if (Game.Instance.board[i].id == id)
            {
                numHouse = Game.Instance.board[i].numHouses;
                colour = Game.Instance.board[i].colour;
            }
        }
        int hold = 0;
        for (int i = 0; i < Game.Instance.board.Length; i++)
        {
            if (Game.Instance.board[i].colour == colour)
            {
                if (Game.Instance.board[i].owner == Game.Instance.curplayer.id)
                {
                    hold++;
                }
            }
        }
        if (hold == 3)   //need to take account of 2 colour tiles
        {
            ownAll = true;
        }
        else
        {
            ownAll = false;
        }
        
              texty.GetComponent<Text>().text = "You have "+ numHouse +" houses on  " + id + "?"; //change to name
    }

    void OnEnable()
    {
        choiceMade = 0;       
        box.SetActive(true); 
        enabled = true;
        contBut.SetActive(false);
        mortBut.SetActive(false);
        sellBut.SetActive(false);
        upgradeBut.SetActive(true);
        firstSellBut.SetActive(true);
        if (run == false)
        {
            Time.timeScale = 1f;
            run = true;         
        }

    }

    public void firstSellButPress()
    {
        if (numHouse > 0)
        {
            upgradeBut.SetActive(false);
            firstSellBut.SetActive(false);
            contBut.SetActive(true);
            texty.GetComponent<Text>().text = "Selling house on " + id + " for £"; //change to house name

            //change balance NEED PRICE

            for (int i = 0; i < Game.Instance.board.Length; i++)
            {
                if (Game.Instance.board[i].id == id)
                {
                    Game.Instance.board[i].numHouses--;
                }
            }
        }
        else
        {
            upgradeBut.SetActive(false);
            firstSellBut.SetActive(false);
            mortBut.SetActive(true);
            sellBut.SetActive(true);
            texty.GetComponent<Text>().text = "Would you like to Sell or Mortgage " + id + "?"; //change to name
        }
        
    }

    public void upgradeButPress()
    {
        if (ownAll == true)
        {
            upgradeBut.SetActive(false);
            firstSellBut.SetActive(false);
            //pay
            texty.GetComponent<Text>().text = "Buying house on " + id + " for £"; //change to house name
            //BALANCE + HOUSE COST
            contBut.SetActive(true);
        }
        else
        {
            upgradeBut.SetActive(false);
            firstSellBut.SetActive(false);
            texty.GetComponent<Text>().text = "You dont down all properties of this colour"; //change to name
            contBut.SetActive(true);
        }


    }
    public void mortButPress()
    {
        for (int i = 0; i < Game.Instance.board.Length; i++)
        {
            if( Game.Instance.board[i].id == id)
            {
                if (Game.Instance.board[i].mortgaged == true)
                {
                    texty.GetComponent<Text>().text = "You have already mortgaged this property";
                }
                else{
                    texty.GetComponent<Text>().text = "Mortgaged for "+ Game.Instance.board[i].mortgage(); 
                    Game.Instance.curplayer.balance += Game.Instance.board[i].mortgage();
                    Game.Instance.board[i].curPrice = 0;
                    Game.Instance.board[i].mortgaged = true;
                    tempChoiceMade = 1;

                }
            }
        }
    }
    public void sellButPress()
    {
        for (int i = 0; i < Game.Instance.board.Length; i++)
        {
            if (Game.Instance.board[i].id == id)
            {
                if (Game.Instance.board[i].mortgaged)
                {
                    texty.GetComponent<Text>().text = "You have sold this property for " + Game.Instance.board[i].mortPrice;
                    Game.Instance.board[i].curPrice = Game.Instance.board[i].originalPrice;
                    Game.Instance.board[i].owner = 0;
                    Game.Instance.board[i].mortgaged = false;
                    Game.Instance.curplayer.cards.Remove(Game.Instance.board[i].id);
                    tempChoiceMade = 2;
                }
                else
                {
                    texty.GetComponent<Text>().text = "You have sold this property for " + Game.Instance.board[i].originalPrice ;
                    Game.Instance.board[i].curPrice = Game.Instance.board[i].originalPrice;
                    Game.Instance.board[i].owner = 0;
                    Game.Instance.board[i].mortgaged = false;
                    Game.Instance.curplayer.cards.Remove(Game.Instance.board[i].id);
                    tempChoiceMade = 2;
                }
            }
        }

            }
    public void contButPress()
    {
        choiceMade = tempChoiceMade;
        enabled = false;
    }


        // Update is called once per frame
        void Update()
    {
        if (tempChoiceMade >= 1)
        {
            contBut.SetActive(true);
            mortBut.SetActive(false);
            sellBut.SetActive(false);
        }
    }
}
