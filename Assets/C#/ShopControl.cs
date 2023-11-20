using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour
{
    public GameObject thetext;
    private int index;

    public Level1control llt;
    void Start()
    {
        
    }
    public void Anext()
    {
        if (index == thetext.transform.childCount - 1)
        {
            gameObject.SetActive(false);
            llt.AXunluo();
            return;
        }
        thetext.transform.GetChild(index).gameObject.SetActive(false);
        index++;
        thetext.transform.GetChild(index).gameObject.SetActive(true);
    }
    void Update()
    {
        
    }
}
