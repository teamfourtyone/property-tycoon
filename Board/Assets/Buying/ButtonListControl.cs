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
    void Start()
    {
        parent.GetComponent<Text>().text = "Player " + Game.Instance.curplayer.id+"'s Cards";
       
        for (int i = 0; i < Game.Instance.curplayer.cards.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            for (int y = 0; y < Game.Instance.board.Length; y++)
            {
                if (Game.Instance.board[y].id == Game.Instance.curplayer.cards[i])
                {
                    cur = Game.Instance.board[y];
                }
            }
            button.SetActive(true);
            clones.Add(button);
            button.GetComponent<ButtonListButton>().SetText("card id " + Game.Instance.curplayer.cards[i], Game.Instance.curplayer.cards[i], cur);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    void OnEnable()
    {
        parent.GetComponent<Text>().text = "Player " + Game.Instance.curplayer.id + "'s Cards";

        for (int i = 0; i < Game.Instance.curplayer.cards.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            for (int y =0;y< Game.Instance.board.Length; y++)
            {
                if (Game.Instance.board[y].id == Game.Instance.curplayer.cards[i])
                {
                    cur = Game.Instance.board[y];
                }
            }
            button.SetActive(true);
            clones.Add(button);
            clones.Add(button);
            button.GetComponent<ButtonListButton>().SetText("card id " + Game.Instance.curplayer.cards[i], Game.Instance.curplayer.cards[i], cur);

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

