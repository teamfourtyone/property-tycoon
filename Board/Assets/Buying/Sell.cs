using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{

    private GameObject cardP;
    public GameObject panel;
    public bool isEnabled = false;

    //opens the properties menu 

    public void onButClick()
    {
        if (isEnabled == false)
        {
            panel.SetActive(true);
            isEnabled = true;
        }
        else
        {
            panel.SetActive(false);
            isEnabled = false;
        }

    }

}
