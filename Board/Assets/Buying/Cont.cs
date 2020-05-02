using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cont : MonoBehaviour
{
    public GameObject box;
    public GameObject texty;
    public GameObject contBut;
    public bool confirmed = false;
    public bool run;
    public enum Type { draw, pay };
    public Type b;

    public void Start()
    {
        box.SetActive(false); // or false                         
        enabled = false;
    }

    void OnDisable()
    {
        box.SetActive(false); // or false
        contBut.SetActive(false);
        confirmed = false;
    }

    void OnEnable()
    {
        confirmed = false;
        box.SetActive(true); // or false
        contBut.SetActive(true);
        if (run == false)
        {
            Time.timeScale = 1f;
            run = true;
        }

    }

    public void SetText(string a,Type b)
    {
        texty.GetComponent<Text>().text = a;
        this.b = b;
    }


        public void ContButPress()
    {
        confirmed = true;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
