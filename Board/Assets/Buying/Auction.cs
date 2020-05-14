using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Auction : MonoBehaviour
{
    public GameObject panel;
    public GameObject heading;
    public GameObject entry;
    public GameObject confirmBut;
    public GameObject contBut;
    public int count;
    int[] bidArray = new int[6];  //need to change to curNumOfPlayers
    public int auctWin;
    public int winBid;
    public bool finished = false;
    public bool tempFinished = false;

    public void Start()

    {
      //  panel.SetActive(false);      
      //  Debug.Log("auction intialised");
       // enabled = false;

       // Debug.Log("auction enableddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
        count = 0;
        enabled = false;
    }

    void OnDisable()
    {
        //Debug.Log("auction diasssableddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
        heading.SetActive(false); // or false
        entry.SetActive(false); // or false
        confirmBut.SetActive(false); // or false
        panel.SetActive(false);
        contBut.SetActive(false);
        finished = false;
        tempFinished = false;
}

    void OnEnable()
    {
        //Debug.Log("auction enableddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
        count = 0;
        heading.SetActive(true); // or false
        entry.SetActive(true); // or false
        confirmBut.SetActive(true); // or false
        panel.SetActive(true);
        contBut.SetActive(false);
        heading.GetComponent<Text>().text = "Player " + (count) + ", please make your bid.";

    }

    public void confirm()
    {
        //CHECKS BALANCE
        if (Game.players[count].balance < int.Parse(entry.GetComponent<InputField>().text))
        {
            entry.GetComponent<InputField>().text = "That's too much money for you...";
        }
        else
        {
            bidArray[count] = int.Parse(entry.GetComponent<InputField>().text);
            entry.GetComponent<InputField>().text = "";
            count++;


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
                for (int i = 0; i < bidArray.Length; i++)
                {
                    Debug.Log(i);
                    if (bidArray[i] > max)
                    {
                        max = bidArray[i];
                    }

                }

                //FIND PLAYER OF MAX BID
                for (int i = 0; i < bidArray.Length; i++)
                {
                    if (bidArray[i] == max && max > 0)
                    {
                        heading.GetComponent<Text>().text = "Player " + (i) + ", won with a bid of £" + max;
                        auctWin = Game.players[i].id;
                        winBid = max;
                        tempFinished = true;
                        entry.SetActive(false);
                        confirmBut.SetActive(false);
                        contBut.SetActive(true);
                    }
                }
            }
            else
            {
                heading.GetComponent<Text>().text = "Player " + (count) + ", please make your bid.";
            }
        }

    }

    public void ContButPress()
    {
       finished = tempFinished;
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
    

