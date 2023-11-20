using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum mstate
    {
        XunLuo,
        ZhuiZhu,
        GongJi,
    Idle,
}

public class zhauntai
{
    public static bool iskuangbao = false;
}

public class MY_enemg : MonoBehaviour {


    public mstate my_state = mstate.XunLuo;

    Animator m_ani;

    NavMeshAgent m_agent;

    GameObject m_player;

    public GameObject[] point;
    bool IsShoot=true;

    int index = 0;
    // Use this for initialization
    void Start () {
        m_ani = this.GetComponent<Animator>();

        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        m_player = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void Shoot()
    {
        if (GameObject.Find("Attack").GetComponent<AudioSource>().isPlaying)
        {

        }
        else
        {
            GameObject.Find("Attack").GetComponent<AudioSource>().Play();
        }
        if (m_player.GetComponent<Level1control>().hpima.fillAmount<=0)
        {
            m_ani.SetBool("attack", false);
            CancelInvoke("Shoot");
            my_state = mstate.Idle;
            return;
        }
        m_player.GetComponent<Level1control>().Cuthp();
    }
    // Update is called once per frame
    void Update () {
        m_player = GameObject.FindGameObjectWithTag("Player");
        switch (my_state)
        {
            case mstate.XunLuo:

                m_ani.SetBool("attack", false);
                if (point.Length > 0)
                {

                    m_agent.SetDestination(point[index].transform.position);

                    if (Vector3.Distance(transform.position, point[index].transform.position) <= 1)
                    {
                        index++;

                        if (index == point.Length)
                        {
                            index = 0;
                        }
                        m_agent.SetDestination(point[index].transform.position);

                    }
                }

                if (Vector3.Distance(transform.position, m_player.transform.position) <10)
                {
                    my_state = mstate.ZhuiZhu;
                    break;
                }
                break;
            case mstate.ZhuiZhu:
                if(IsShoot==false)
                {
                    IsShoot = true;
                    CancelInvoke("Shoot");
                }
                m_ani.SetBool("attack", false);
                m_agent.SetDestination(m_player.transform.position);

                if (Vector3.Distance(transform.position, m_player.transform.position) >10)
                {
                    my_state = mstate.XunLuo;
                }

                if (Vector3.Distance(transform.position, m_player.transform.position) <2)
                {
                    my_state = mstate.GongJi;
                }

                break;
            case mstate.GongJi:
                if(IsShoot)
                {
                    IsShoot = false;
                    InvokeRepeating("Shoot", 1, 1);
                }
                m_agent.ResetPath();
                m_ani.SetBool("attack", true);
                RotateTo();
                if (Vector3.Distance(transform.position, m_player.transform.position) >2)
                {
                    my_state = mstate.ZhuiZhu;
                }

                break;
            case mstate.Idle:
                CancelInvoke("Shoot");
                m_agent.ResetPath();
                break;
        }
    }


    void RotateTo()
    {
        Vector3 targetdir = m_player.transform.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetdir, 5 * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

}
