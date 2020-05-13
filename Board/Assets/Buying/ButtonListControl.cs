using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;
    public GameObject parent;
    private List<int> intlist;
    private Text playerText;
    public List<GameObject> clones = new List<GameObject>();

    void Start()
    {
        parent.GetComponent<Text>().text = "Player " + Game.currentPlayer.id+"'s Cards";
       
        for (int i = 0; i < Game.currentPlayer.cards.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;

            button.SetActive(true);
            clones.Add(button);
            button.GetComponent<ButtonListButton>().SetText("card id " + Game.currentPlayer.cards[i], Game.currentPlayer.cards[i]);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    void OnEnable()
    {
        parent.GetComponent<Text>().text = "Player " + Game.currentPlayer.id + "'s Cards";

        for (int i = 0; i < Game.currentPlayer.cards.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;

            button.SetActive(true);
            clones.Add(button);
            clones.Add(button);
            button.GetComponent<ButtonListButton>().SetText("card id " + Game.currentPlayer.cards[i], Game.currentPlayer.cards[i]);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    void OnDisable()
    {
        foreach (GameObject clone in clones)
        {
            Destroy(clone);
        }
    }

    void GenButtons()
    {

    }
}

