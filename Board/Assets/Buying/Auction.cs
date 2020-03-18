using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Auction : MonoBehaviour
{
    public GameObject heading;
    public GameObject entry;
    public GameObject confirmBut;
    

    public int count;
    int[] bidArray = new int[6];  //need to change to curNumOfPlayers
    public int auctWin;

    public void Start()

    {
        heading.GetComponent<Text>().text = "Player " + (count+1) + ", please make your bid.";
    }

    public void confirm()
    {
        /*CHECKS BALANCE
        if (Game.players[count].balance < int.Parse(entry.GetComponent<InputField>().text))  //NEED TO FIX ACCESS TO PLAYERLIST
        {
            entry.GetComponent<InputField>().text = "That's too much money for you...";
        }
        else
        {
            bidArray[count] = int.Parse(entry.GetComponent<InputField>().text);
            entry.GetComponent<InputField>().text = "";
            count++;
            */

        //IF BIDDING COMPLETE
        if (count == bidArray.Length)
        {
            entry.SetActive(false);
            confirmBut.SetActive(false);
            Debug.Log("DONE");
            Debug.Log(bidArray);
            foreach (int a in bidArray)
            {
                Debug.Log(a);
            }

            //FIND MAX BID
            int max = 0;
            for(int i = 0;i< bidArray.Length;i++)
            {
                Debug.Log(i);
                if (bidArray[i] > max)
                {
                    max = bidArray[i];
                }

            }

            //FIND PLAYER OF MAX BID
            for(int i = 0;i< bidArray.Length;i++)
            {
               if (bidArray[i] == max && max > 0)
               {
                    heading.GetComponent<Text>().text = "Player " + (i + 1) + ", won with a bid of £" + max;
                    auctWin = Game.players[i].id; //access problems
              }
            }
        }
        else
        {
            heading.GetComponent<Text>().text = "Player " + (count + 1) + ", please make your bid.";            
        }
        //}

    }
 
    void Update()
    {
       
        if (count == bidArray.Length)
        {
           // Debug.Log("DONE");
            Debug.Log(bidArray[3]);
            
        }
    }
}
