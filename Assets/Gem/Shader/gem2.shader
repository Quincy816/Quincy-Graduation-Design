// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Unlit/gem2"
{
	Properties
	{
		_Color("Gem COlor", Color)=(1,1,1,1)
		_Emission("_Emission", Color)=(0,0,0,0)
		_RefractTex("RefractCube", Cube)="white"{}
		//_EnvTex("Env Texture", Cube)="white"{}
		_FresnelTex("Fresnel", 2D)="white"{}
		_SpecularPower("Specular Power&Specular Intensity&Reflection Strength", Vector)=(8,1,0.15,0)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "LightMode"="ForwardBase"}
		LOD 100
	
		CGINCLUDE
		#include "UnityCG.cginc"
		#include "Lighting.cginc"
		struct appdata
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		//	float2 uv : TEXCOORD0;
		};

		struct v2f
		{
			float3 refractVector:TEXCOORD0;
			float3 reflectVector:TEXCOORD1;
			float4 vertex : SV_POSITION;
		};
		struct v2f2
		{
			float3 refractVector:TEXCOORD0;
			float4 reflectVector:TEXCOORD1;
			float3 refractVector2:TEXCOORD2;
			float3 refractVector3:TEXCOORD3;
			float4 vertex : SV_POSITION;
		};

		float4 _Color;
		float4 _Emission;
		samplerCUBE _RefractTex;
		//samplerCUBE _EnvTex;
		sampler2D _FresnelTex;
		float3 _SpecularPower;

//			inline half FastFresnel(float3 I, float3 N, float R0){
//				float icosIN = saturate(1-dot(I, N));
//				float i2 = icosIN*icosIN;
//				float i4 = i2*i2;
//				return R0+(1-R0)*(i4*icosIN);
//			}

		float3 MyRefract(float3 I, float3 N, float eta){
			float c1 = -dot(I, N);
			float cs2 = 1.0f - eta*eta*(1.0f - c1*c1);
			//not consider total reflection
			cs2 = abs(cs2);
			float3 v = (eta*I + (eta*c1-sqrt(cs2))*N);
			//consider total reflection
			//float3 v = (eta*I + (eta*c1-sqrt(cs2))*N);
			//v = lerp(v, I, step(cs2, 0));
			return v;
		}

		v2f vert (appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);

			float3 worldNormal = normalize( mul((float3x3)unity_ObjectToWorld, v.normal) );
			float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
			float3 view = normalize(worldPos - _WorldSpaceCameraPos.xyz);
			//from diamond to air. eta = 2.4/1;
			o.refractVector = MyRefract(view, worldNormal, 2.4f);
			o.reflectVector.xyz = reflect(view, worldNormal);

			return o;
		}

		v2f2 vert2 (appdata v)
		{
			v2f2 o;
			o.vertex = UnityObjectToClipPos(v.vertex);

			float3 worldNormal = normalize( mul((float3x3)unity_ObjectToWorld, v.normal) );
			float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
			float3 view = normalize(worldPos - _WorldSpaceCameraPos.xyz);
	
			//from air to diamond. eta = 1/2.4;
			o.refractVector = refract(view, worldNormal, 1/2.40f);//red
			o.refractVector2 = refract(view, worldNormal, 1/2.41f);//green
			o.refractVector3 = refract(view, worldNormal, 1/2.417f);//blue

			o.reflectVector.xyz = reflect(view, worldNormal);
			o.reflectVector.w = dot(-view, worldNormal);

			return o;
		}
		
		float4 frag (v2f i) : SV_Target
		{
			float4 result = float4(0,0,0,1);

			half3 refractColor = texCUBE(_RefractTex, normalize(i.refractVector));
			half3 reflectColor = texCUBE(_RefractTex, normalize(i.reflectVector.xyz));

			//If the _RefractTex opened the linear space option, dont do this.
			//if(IsGammaSpace()){
				//refractColor = pow(refractColor, 2.2f);
				//reflectColor = pow(reflectColor, 2.2f);
			//}

			result.xyz = 0.6f * (refractColor + reflectColor + _Emission.xyz)*_Color.xyz*_LightColor0.xyz;

			if(IsGammaSpace()){
				result.xyz = pow(result.xyz, 1/2.2f)*0.85f;
			}

			return result;
		}

		half4 frag2 (v2f2 i) : SV_Target
		{
			half4 result = float4(0,0,0,1);

			half3 refractColor = float3(0,0,0);
			refractColor.r = texCUBE(_RefractTex, normalize(i.refractVector)).r;
			refractColor.g = texCUBE(_RefractTex, normalize(i.refractVector2)).g;
			refractColor.b = texCUBE(_RefractTex, normalize(i.refractVector3)).b;

			half3 reflectVector = normalize(i.reflectVector.xyz);
			half4 specColor0 = UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0, reflectVector, 0);
			half3 reflColor0 = DecodeHDR(specColor0, unity_SpecCube0_HDR);

			#ifdef UNITY_SAMPLE_TEXCUBE_SAMPLER_LOD
			half4 specColor1 = UNITY_SAMPLE_TEXCUBE_SAMPLER_LOD(unity_SpecCube1, unity_SpecCube0, reflectVector, 0);
			#else
			half4 specColor1 = UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube1, reflectVector, 0);
			#endif

			half3 reflColor1 = DecodeHDR(specColor1, unity_SpecCube1_HDR);
			half3 reflectColor = reflColor0 * unity_SpecCube0_BoxMin.w + reflColor1 * (1-unity_SpecCube0_BoxMin.w);

			float fresnel = tex2D(_FresnelTex, half2(i.reflectVector.w, 0.5f)).r;

			//
			if(IsGammaSpace()){
				//refractColor = pow(refractColor, 2.2f);//If the _RefractTex opened the linear space option, dont do this.
				//reflectColor = pow(reflectColor, 2.2f);//ditto
				fresnel = pow(fresnel, 2.2f);
			}
			//
			refractColor = refractColor*_Color.xyz*_LightColor0.xyz + _Emission.xyz;
			result.xyz = refractColor.xyz + reflectColor.xyz * fresnel * _SpecularPower.z;
			//calculate specular
			half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
			float RL = saturate(dot(i.reflectVector, lightDir));
			half3 specularColor = _SpecularPower.y*pow(RL, _SpecularPower.x)*_LightColor0.xyz;

			result.xyz = result.xyz + specularColor.xyz;

			if(IsGammaSpace()){
				result.xyz = pow(result.xyz, 1/2.2f)*0.85f;
			}

			return result;
		}
		ENDCG
		
		Pass
		{
			Cull Front
			//ZWrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			#pragma target 2.0
			ENDCG
		}
		Pass
		{
			ZWrite on
			//Blend one one
			Blend srccolor dstcolor
			CGPROGRAM
			#pragma vertex vert2
			#pragma fragment frag2
			#pragma multi_compile_fwdbase
			#pragma target 2.0
			ENDCG
		}
	}
}
