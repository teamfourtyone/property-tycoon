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
    public int choiceMade = 0;
    public bool run = false;

    public void Start()
    {         
        enabled = false;
        choiceMade = 0;
    }

    void OnDisable()
    {
        box.SetActive(false); // or false
        choiceMade = 0;
    }

    void OnEnable()
    {
        Time.timeScale = 0f;
        choiceMade = 0;
        box.SetActive(true); // or false
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
        choiceMade = 1;
        GetComponent<Choice>().enabled = false;
    }

    public void UpgradeButPress()
    {
        texty.GetComponent<Text>().text = "Congratulations on Your Upgrade";
        choiceMade = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (choiceMade >= 1)
        {
            passBut.SetActive(false);
            upgradeBut.SetActive(false);
        }
    }
}
