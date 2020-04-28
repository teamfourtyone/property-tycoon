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
    public int choiceMade= 0;
    public bool run = false;
    
    public void Start()
    {
        box.SetActive(false); // or false
        Debug.Log("buy intialised");
        enabled = false;
    }

    void OnDisable()
    {
        Debug.Log("buy disabled");
        box.SetActive(false); // or false
        noBut.SetActive(false);
        yesBut.SetActive(false);      
        choiceMade = 0;
    }

    void OnEnable()
    {
        
        Debug.Log("buy enabled");
        choiceMade = 0;
        texty.GetComponent<Text>().text = "Would you like to buy this property?";
        box.SetActive(true); // or false
        noBut.SetActive(true);
        yesBut.SetActive(true);
        //Debug.Log("pausing game");
        Time.timeScale = 0f;
        if (run == false)
        {
            Time.timeScale = 1f;
            run = true;
            Debug.Log("unpausing game");
        }

    }


        public void NoButPress()
    {
        texty.GetComponent<Text>().text = "To Auction!";
        choiceMade = 1;
        
    }  

    public void YesButPress()
    {
        texty.GetComponent<Text>().text = "Congratulations on Your Purchase";
        choiceMade = 2;
    }

    // Update is called once per frame
    void Update()
    {
         if (choiceMade >= 1)
        {
            noBut.SetActive(false);
            yesBut.SetActive(false);
        }
    }
}
