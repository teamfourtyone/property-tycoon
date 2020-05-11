using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText; 
    public int cardId;
    public GameObject mo;
    public GameObject panel;


    public void SetText(string textString,int id)
    {
        myText.text = textString;
        cardId = id;
    }

    public void onClick()
    {
        mo.SetActive(true);
        mo.GetComponent<Mort>().enabled = true;
        mo.GetComponent<Mort>().setParam(cardId);
        panel.SetActive(false);
    }
}
