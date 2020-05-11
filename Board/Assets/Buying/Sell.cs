using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{

    private GameObject cardP;
    public GameObject panel;
    public bool isEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onButClick()
    {
        if (isEnabled == false){
            panel.SetActive(true);
            isEnabled = true;
        }
        else
        {
            panel.SetActive(false);
            isEnabled = false;
        }

        //cardP.GetComponent<ButtonListControl>().enabled = true;
    }
   
}
