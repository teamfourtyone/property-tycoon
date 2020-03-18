using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
   
    bool buying = false;
    bool open = false;
    int i = 0;
    public GameObject box;
    public GameObject texty;
    public GameObject noBut;
    public GameObject yesBut;
    public int choiceMade= 0;

    
    public void Start()
    {
        open = true;
        //makes BuyCanvas + children visable
        //GetComponent<CanvasGroup>().alpha = 1f;
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
