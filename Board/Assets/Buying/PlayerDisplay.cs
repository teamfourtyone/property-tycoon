using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{

    public GameObject playerText;
   // private Text playerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerText.GetComponent<Text>().text = "Player " + Game.currentPlayer.id ;
    }
}
