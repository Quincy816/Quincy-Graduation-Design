using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void Aload(string name)
	{
		SceneManager.LoadScene(name);
	}
    public void Ares()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
