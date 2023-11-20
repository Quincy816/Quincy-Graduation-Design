using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS : MonoBehaviour {
	[SerializeField]
	private Text m_fps;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount % 10 == 0)
		{
			int fps = (int)(1.0f/Time.deltaTime);
			m_fps.text = fps.ToString();
		}
	}
}
