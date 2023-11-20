using UnityEngine;
using System.Collections;

public class CrossFlare_ZM : MonoBehaviour {
	public bool m_isOpen = true;
	public Shader m_blurShader;
	public Shader m_cutoffShader;
	public Shader m_blendShader;
	public LayerMask m_layerMask;
	public float m_blurSize = 1.0f;
	public Vector2 BlurOffset = new Vector2(-0.01f, 0.01f);
	public Vector2 BlurDir=new Vector2(1,0.5f);
	public float m_lum = 1;
	public float m_lumCutoff = 0.85f;
	
	private Camera m_maskCamera;
	private RenderTexture m_renderTex;
	private Material m_blendMat;
	public Material BlendMat
	{
		get
		{
			if(null == m_blendMat)
			{
				m_blendMat = new Material(m_blendShader);
				m_blendMat.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_blendMat;
		}
		set
		{
			m_blendMat = value;
		}
	}


	private Material m_blurMat;
	protected Material BlurMat
	{
		get
		{
			if(null == m_blurMat)
			{
				m_blurMat = new Material(m_blurShader);
				m_blurMat.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_blurMat;
		}
	}

	private Material m_cutoffMat;
	protected Material CutoffMat
	{
		get
		{
			if(null == m_cutoffMat)
			{
				m_cutoffMat = new Material(m_cutoffShader);
				m_cutoffMat.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_cutoffMat;
		}
	}

	
	// Use this for initialization
	void Start () {
		if(!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
		if(!BlurMat.shader.isSupported)
			enabled = false;
		if(!BlendMat.shader.isSupported)
			enabled = false;
		if(!CutoffMat.shader.isSupported)
			enabled = false;

		CopyCamera();
		m_renderTex = new RenderTexture(m_maskCamera.pixelWidth,
		                                m_maskCamera.pixelHeight, 24);
		m_renderTex.filterMode = FilterMode.Point;
		m_maskCamera.targetTexture = m_renderTex;
		//
		if(m_blurSize < 0.0625f)
		{
			m_blurSize = 0.0625f;
		}
	}

	void CopyCamera()
	{
		GameObject go = new GameObject("BlurMaskCamera");
		m_maskCamera = go.AddComponent<Camera>();
		m_maskCamera.CopyFrom(Camera.main);
		//m_maskCamera.enabled = false;
		m_maskCamera.clearFlags = CameraClearFlags.SolidColor;
		m_maskCamera.backgroundColor = Color.black;
		m_maskCamera.hideFlags = HideFlags.HideAndDontSave;
		m_maskCamera.cullingMask = (m_layerMask);
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if(!m_isOpen)
		{
			Graphics.Blit(source, destination);
			return;
		}

		RenderTexture lightTex = RenderTexture.GetTemporary(Mathf.FloorToInt(source.width*0.0625f/m_blurSize), 
		                                                    Mathf.FloorToInt(source.height*0.0625f/m_blurSize));
		RenderTexture blurTexH = RenderTexture.GetTemporary(Mathf.FloorToInt(source.width*0.5f), 
		                                                    Mathf.FloorToInt(source.height*0.5f));
		RenderTexture blurTexV = RenderTexture.GetTemporary(Mathf.FloorToInt(source.width*0.5f), 
		                                                    Mathf.FloorToInt(source.height*0.5f));

		CutoffMat.SetFloat("_LumCutoff", m_lumCutoff);
		CutoffMat.SetFloat ("_Lum", m_lum);
		Graphics.Blit (m_maskCamera.targetTexture, lightTex, CutoffMat);

		Vector2 dir = BlurDir.normalized;

		for(int i=1, j=1; i<=8; i+=2, j++)
		{
			m_blurMat.SetVector("_Off"+j, new Vector4(i*dir.x,i*dir.y,(i+1)*dir.x,(i+1)*dir.y));
		}
		m_blurMat.SetVector ("_BlurOffset", BlurOffset);
		m_blurMat.SetVector("_Weight1", new Vector4(0.4f, 0.35f, 0.3f, 0.25f));
		m_blurMat.SetVector("_Weight2", new Vector4(0.2f, 0.15f, 0.1f, 0.05f));
		Graphics.Blit (lightTex, blurTexH, BlurMat);

		for(int i=1, j=1; i<=8; i+=2, j++)
		{
			m_blurMat.SetVector("_Off"+j, new Vector4(-i*dir.y,i*dir.x,-(i+1)*dir.y,(i+1)*dir.x));
		}
		Graphics.Blit (lightTex, blurTexV, m_blurMat);

		BlendMat.SetTexture("_BlurTexH", blurTexH);
		BlendMat.SetTexture("_BlurTexV", blurTexV);
		Graphics.Blit (source, destination, BlendMat);

		RenderTexture.ReleaseTemporary(lightTex);
		RenderTexture.ReleaseTemporary(blurTexH);
		RenderTexture.ReleaseTemporary(blurTexV);
	}
	
}
