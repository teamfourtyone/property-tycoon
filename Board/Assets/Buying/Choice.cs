using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Choice : MonoBehaviour
{
    public GameObject box;
    public GameObject texty;
    public GameObject passBut;
    public GameObject upgradeBut;
    public GameObject contBut;
    public int choiceMa = 0;
    public bool run = false;
    private int tempChoiceMa = 0;

    public void Start()
    {
        enabled = false;
        choiceMa = 0;
        tempChoiceMa = 0;
    }

    void OnDisable()
    {
        box.SetActive(false); // or false
        choiceMa = 0;
        tempChoiceMa = 0;
        contBut.SetActive(false);
    }

    void OnEnable()
    {
        texty.GetComponent<Text>().text = "You own this property. Would you like to upgrade ? ";
        choiceMa = 0;
        tempChoiceMa = 0;
        box.SetActive(true);
        passBut.SetActive(true);
        upgradeBut.SetActive(true);
        if (run == false)
        {
            Time.timeScale = 1f;
            run = true;
            Debug.Log("unpausing game");
        }

    }


    public void PassButPress()
    {
        texty.GetComponent<Text>().text = "Next Player";
        tempChoiceMa = 3;

    }

    public void UpgradeButPress()
    {
        texty.GetComponent<Text>().text = "Please Upgtade Using The Properties Menu Above";
        tempChoiceMa = 4;
    }

    public void ContButPress()
    {
        choiceMa = tempChoiceMa;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempChoiceMa >= 1)
        {

            passBut.SetActive(false);
            upgradeBut.SetActive(false);
            contBut.SetActive(true);
        }
    }
}
