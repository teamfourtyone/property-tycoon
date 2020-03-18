
using UnityEngine;

public class TileStreet : Tile
{ 
    public string colour;
    public int numHouses;
    public bool mortgaged;
    public int orininalPrice;
    public int curPrice;
    public int choice;
    public GameObject go;
    public Player landedPlayer;

    public TileStreet(int i)
    {
        numHouses = 0;
        mortgaged = false;
        owner = 0;
        id = i;
    }

    public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
    {

        Debug.Log("Landed on tile " + id + ".");
        if (owner != 0)
        {
            landedPlayer = currentPlayer;
            if (currentPlayer.id == owner)
            {
                Debug.Log("upgrade?");
                //popup yes/no TODO visual, adapt buy menu?
                upgrade(currentPlayer);
            }
            else
            {
                currentPlayer.balance -= this.curPrice;
                if (currentPlayer.balance <= 0)
                {
                    //START MORTGAGE TODO
                    mortgage(currentPlayer);
                }
            }
        }
        else
        {
            //BUY
            choice = 3;
        }


        
        if (choice == 1)
        {

        }
        if (choice == 2)
        {

        }
        if (choice == 3)
        {
            go.GetComponent<Buy>().Start();
            while (go.GetComponent<Buy>().choiceMade != 0)
            {
                //waits for buy.cs to finish
            }
            if (go.GetComponent<Buy>().choiceMade == 1)
            {
                go.GetComponent<Auction>().Start();
                buy(go.GetComponent<Auction>().auctWin);
            }
            if (go.GetComponent<Buy>().choiceMade == 2)
            {
                //buy
                buy(landedPlayer);
            }
        }
        nextPlayer.move(board);
    }

    void Update()
    {
       
    }
}

    
