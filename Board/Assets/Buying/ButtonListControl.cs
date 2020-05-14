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
    public Tile cur;

    
    
    void OnEnable()
    {
        parent.GetComponent<Text>().text = "Player " + Game.currentPlayer.id + "'s Cards";

        for (int i = 0; i < Game.currentPlayer.cards.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            for (int y = 0; y < Game.board.Length; y++)
            {
                if (Game.board[y].id == Game.currentPlayer.cards[i])
                {
                    cur = Game.board[y];

                }
            }
                
                button.SetActive(true);
           
                clones.Add(button);
                button.GetComponent<ButtonListButton>().SetText("card id " + Game.currentPlayer.cards[i], Game.currentPlayer.cards[i], cur);

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

