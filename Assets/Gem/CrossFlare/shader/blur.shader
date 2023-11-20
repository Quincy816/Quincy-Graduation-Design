// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CrossFlare_ZM/blur" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BlurDist ("motion blur distance", float) = 1
		_BlurStrength("blur strength", float) = 1
		_Weight1 ("blur weight", vector) = (0.4, 0.35, 0.3, 0.25)
		_Weight2 ("blur weight", vector) = (0.2, 0.15, 0.1, 0.05)
	}
	

	Subshader {
		ZTest Always Cull Off ZWrite Off Fog { Mode Off }
		Pass {
			CGPROGRAM
				#pragma target 3.0
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest

				#include "UnityCG.cginc"

				struct v2f {
					float4 pos : POSITION;
					half2 uv : TEXCOORD0;
					half2 offuv[8] : TEXCOORD1;
				};
				sampler2D _MainTex;
				half4 _MainTex_TexelSize;
				half4 _Off1;
				half4 _Off2;
				half4 _Off3;
				half4 _Off4;
				half4 _Weight1;
				half4 _Weight2;
				half _BlurDist;
				half _BlurStrength;
				half2 _BlurOffset;

				v2f vert (appdata_img v)
				{
					v2f o;
					float tsx = _MainTex_TexelSize.x;
					float tsy = _MainTex_TexelSize.y;

					o.pos = UnityObjectToClipPos (v.vertex);
					half2 uv = MultiplyUV (UNITY_MATRIX_TEXTURE0, v.texcoord.xy);
					o.uv = uv;
				
					o.offuv[0].xy = half2( _Off1.x*tsx, _Off1.y*tsy)*_BlurDist;
					o.offuv[1].xy = half2( _Off1.z*tsx, _Off1.w*tsy)*_BlurDist;
					o.offuv[2].xy = half2( _Off2.x*tsx, _Off2.y*tsy)*_BlurDist;
					o.offuv[3].xy = half2( _Off2.z*tsx, _Off2.w*tsy)*_BlurDist;
					o.offuv[4].xy = half2( _Off3.x*tsx, _Off3.y*tsy)*_BlurDist;
					o.offuv[5].xy = half2( _Off3.z*tsx, _Off3.w*tsy)*_BlurDist;
					o.offuv[6].xy = half2( _Off4.x*tsx, _Off4.y*tsy)*_BlurDist;
					o.offuv[7].xy = half2( _Off4.z*tsx, _Off4.w*tsy)*_BlurDist;
					
					return o;
				}

				half4 frag( v2f i ) : COLOR
				{
					half4 c=half4(0,0,0,0);
					c += tex2D( _MainTex, i.uv+i.offuv[0]+_BlurOffset )*_Weight1.x;
					c += tex2D( _MainTex, i.uv+i.offuv[1]+_BlurOffset )*_Weight1.y;
					c += tex2D( _MainTex, i.uv+i.offuv[2]+_BlurOffset )*_Weight1.z;
					c += tex2D( _MainTex, i.uv+i.offuv[3]+_BlurOffset )*_Weight1.w;
					c += tex2D( _MainTex, i.uv+i.offuv[4]+_BlurOffset )*_Weight2.x;
					c += tex2D( _MainTex, i.uv+i.offuv[5]+_BlurOffset )*_Weight2.y;
					c += tex2D( _MainTex, i.uv+i.offuv[6]+_BlurOffset )*_Weight2.z;
					c += tex2D( _MainTex, i.uv+i.offuv[7]+_BlurOffset )*_Weight2.w;
					
					c += tex2D( _MainTex, i.uv-i.offuv[0]+_BlurOffset )*_Weight1.x;
					c += tex2D( _MainTex, i.uv-i.offuv[1]+_BlurOffset )*_Weight1.y;
					c += tex2D( _MainTex, i.uv-i.offuv[2]+_BlurOffset )*_Weight1.z;
					c += tex2D( _MainTex, i.uv-i.offuv[3]+_BlurOffset )*_Weight1.w;
					c += tex2D( _MainTex, i.uv-i.offuv[4]+_BlurOffset )*_Weight2.x;
					c += tex2D( _MainTex, i.uv-i.offuv[5]+_BlurOffset )*_Weight2.y;
					c += tex2D( _MainTex, i.uv-i.offuv[6]+_BlurOffset )*_Weight2.z;
					c += tex2D( _MainTex, i.uv-i.offuv[7]+_BlurOffset )*_Weight2.w;
					
					c *= _BlurStrength;
					
					return c;
				}
			ENDCG
		}
	} 
	FallBack off
}
