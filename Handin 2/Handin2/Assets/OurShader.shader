Shader "Handin2/OurShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TextureScale("Texture Scale", Range(0,10)) = 1
	}
	SubShader
	{
		Tags {"Queue"="Geometry"}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert 		//compile function vert as the vertex shader. 
			#pragma fragment frag 		//compile function frag as the fragment shader.

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct vert2frag
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;				
			};

			sampler2D _Texture
			float4 _TextureScale;
			
			vert2frag vert (appdata v)
			{
				vert2frag o;
				v.position = UnityObjectToClipPos(v.position);
				v.normDeviceCoords = UnityObjectToClipPos(v.position); 
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
