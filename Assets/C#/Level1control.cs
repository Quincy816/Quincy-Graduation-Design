using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1control : MonoBehaviour
{
    private GameObject Now_obj;

    public Text Fueltext;
    public int  fuelnum;
    public Image hpima;

    public GameObject LoseUI,WinUI,Dieobj;


    public GameObject thebtns, theunlocks;

    public GameObject Talk1, Talk2, Talk3, Talk4, Talk5;
    private float shop_num;
    void Start()
    {
        for (int i = 0; i < thebtns.transform.childCount; i++)
        {
            GameObject theobj = thebtns.transform.GetChild(i).gameObject;
            thebtns.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
            {
                ABuy(theobj);
            });
        }
    }
    public void AXunluo()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<MY_enemg>().my_state = mstate.XunLuo;
        }
    }
    public void Ares()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<MY_enemg>().my_state = mstate.Idle;
        }
    }
    public void ABuy(GameObject obj)
    {
        if (obj.GetComponent<CoinNum>().Num <= fuelnum)
        {
            fuelnum -= obj.GetComponent<CoinNum>().Num;
            Fueltext.text = ":" + fuelnum;
            for (int i = 0; i < theunlocks.transform.childCount; i++)
            {
                if (theunlocks.transform.GetChild(i).gameObject.name == obj.name)
                {
                    theunlocks.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            obj.SetActive(false);
            GameObject.Find("true").GetComponent<AudioSource>().Play();
            shop_num+=0.5f;
            if (shop_num == 1)
            {
                Talk1.SetActive(true);
                Ares();
            }
            if (shop_num == 2)
            {
                Talk2.SetActive(true);
                Ares();
            }
            if (shop_num == 3)
            {
                Talk3.SetActive(true);
                Ares();
            }
            if (shop_num == 4)
            {
                Talk4.SetActive(true);
                Ares();
            }
            if (shop_num == 5)
            {
                Talk5.SetActive(true);
                Ares();
            }
        }
        else
        {
            GameObject.Find("false").GetComponent<AudioSource>().Play();
        }
    }

    public void Cuthp()
    {
        hpima.fillAmount -= 0.1f;
        int index=Random.Range(0, 10);
        if (index < 3&& fuelnum > 1)
        {
            fuelnum--;
            Fueltext.text = ":" + fuelnum;
        }
        if (hpima.fillAmount <= 0)
        {
            LoseUI.SetActive(true);
            Dieobj.SetActive(true);
            Dieobj.transform.SetParent(null);
            gameObject.SetActive(false);


            GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].SetActive(false);
            }
        }

    }
    public void AWin()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(false);
        }
        WinUI.SetActive(true);
    }
    public void ACoin(int index)
    {
        fuelnum+= index;
        Fueltext.text = ":" + fuelnum;
        GameObject.Find("fuelaud").GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            ACoin(1);
        }
        if (other.tag == "gem")
        {
            Destroy(other.gameObject);
            ACoin(10);
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
