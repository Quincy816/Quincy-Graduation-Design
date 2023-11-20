// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CrossFlare_ZM/blend" {
Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		ZTest Always Cull Off ZWrite Off Fog { Mode Off }
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass {
		CGPROGRAM
			//#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_TexelSize;
			sampler2D _BlurTexH;
			sampler2D _BlurTexV;
			struct v2f
			{
				half4 pos : POSITION;
				half2 uv : TEXCOORD0;
			};

			v2f vert(appdata_base i)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(i.vertex);
				o.uv.xy = i.texcoord.xy;
				//o.uv.zw = MultiplyUV (UNITY_MATRIX_TEXTURE0, i.texcoord.xy);
				return o;
			}
			float4 frag(v2f i):COLOR
			{
				float4 result;
				float4 blurH, blurV;
				result = tex2D(_MainTex, i.uv.xy);
				float2 blurUV = i.uv;
				#if UNITY_UV_STARTS_AT_TOP
				if (_MainTex_TexelSize.y < 0)
					blurUV.y = 1 - blurUV.y;	
				#endif
				//i.uv.w = 1-i.uv.w;
				blurH = tex2D(_BlurTexH, blurUV);
				blurV = tex2D(_BlurTexV, blurUV);
				//result.rgb = result.rgb*(blur.a) + blur.rgb;
				result.rgb =  (blurV.rgb+blurH.rgb)+result.rgb;
				return result;
			}
		ENDCG
		}
	} 
	FallBack "Diffuse"
}
