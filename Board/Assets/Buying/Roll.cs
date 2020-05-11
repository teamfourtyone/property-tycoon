using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public GameObject go;
    public GameObject rollPan;
    public GameObject rollBut;
    public GameObject rollResults;
    // Start is called before the first frame update
    int dieOne = 0;
    int dieTwo = 1;

    void Start()
    {
        rollPan.SetActive(false);
    }

    void OnEnable()
    {
        rollPan.SetActive(true);
        rollBut.SetActive(true);
    }

    public void setDice(int d1, int d2)
    {
        dieOne = d1;
        dieTwo = d2;      
    }
    public void OnClick()
    {
       rollBut.SetActive(false);
       go.GetComponent<Cont>().enabled = true;
       go.GetComponent<Cont>().SetText("Player " + Game.Instance.nextplayer.id + " rolled " + Game.Instance.nextplayer.d1+ " and "+ Game.Instance.nextplayer.d2, Cont.Type.roll);
    }
    // Update is called once per frame
    void Update()
    {
        if (go.GetComponent<Cont>().confirmed == true && go.GetComponent<Cont>().b == Cont.Type.roll)
        {
            go.GetComponent<Cont>().enabled = false;
            Time.timeScale = 1f;
            rollPan.SetActive(false);

        }
    }
}
