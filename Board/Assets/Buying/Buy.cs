using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    // Start is called before the first frame update

    bool buying = false;
    bool open = false;
    int i = 0;
    void Start()
    {
        open = true;
        //makes BuyCanvas + children visable
        GetComponent<CanvasGroup>().alpha = 1f;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
