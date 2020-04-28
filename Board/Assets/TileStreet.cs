
using UnityEngine;

public class TileStreet : Tile 
{ 
    public string colour;   
    public bool mortgaged;
    public int orininalPrice;
    public int curPrice;

    public int choice;
    public GameObject go;
    public static Player landedPlayer;
    public static Player nextPlayerr;
    public Tile[] boardy;
    public bool ready;
 
    public TileStreet(int i)
    {
        numHouses = 0;
        mortgaged = false;
        owner = 0;
        id = i;
       
    }

  
    public override void landingAction(Player currentPlayer, Player nextPlayer, Tile[] board)
    {

       // Time.timeScale = 0f;
        go = GameObject.Find("GameController");

        landedPlayer = currentPlayer;
        nextPlayerr = nextPlayer;
        boardy = board;

        Debug.Log("LLLLLLLLLLL"+currentPlayer.getId());
        
        Debug.Log(go.GetComponent<Buy>().choiceMade);
        Debug.Log("confirmed choise made working" + go.GetComponent<Choice>().choiceMade);
        ready = false;
        Debug.Log("Landed on tile " + id + ".");
        if (owner != 0)
        {
            landedPlayer = currentPlayer;
            if (currentPlayer.id == owner)
            {
                Debug.Log("upgrade?");
                //popup upgrade pass?
                //choice = 1;
                go.GetComponent<Choice>().enabled = true;

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
            Debug.Log("choice 3");
            choice = 3;
            Debug.Log("run buy");
            go.GetComponent<Buy>().enabled = true;
           go.GetComponent<Auction>().enabled = true;
            go.GetComponent<Auction>().enabled = false;


            Debug.Log("fucked");
        }
  
       // nextPlayer.move(board);
    }

    void Update()
    {
        //Debug.Log("CURRUNT CHOICEEE" + GameObject.Find("GameController").GetComponent<Buy>().choiceMade);
        if (go.GetComponent<Choice>().choiceMade == 1)
        {           
                go.GetComponent<Choice>().enabled = false;
                Debug.Log("skipping");
                Time.timeScale = 1f;
                nextp(nextPlayerr, boardy);

        }
        if (go.GetComponent<Choice>().choiceMade == 2)
        {
            upgrade();
            go.GetComponent<Choice>().enabled = false;
            Debug.Log("upgrading");
            Time.timeScale = 1f;
            nextp(nextPlayerr, boardy);
        }

            if (go.GetComponent<Auction>().finished == true)
        {
            buy(go.GetComponent<Auction>().auctWin);
            go.GetComponent<Auction>().enabled = false;
            choice = 0;
            Debug.Log("returns auction");
            Time.timeScale = 1f;
            nextp(nextPlayerr, boardy);
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
                buy(landedPlayer);
                go.GetComponent<Buy>().enabled = false;
                choice = 0;
                Debug.Log("returns choise 2");
                Time.timeScale = 1f;
            nextp(nextPlayerr, boardy);
        }
        
    }
}

    
