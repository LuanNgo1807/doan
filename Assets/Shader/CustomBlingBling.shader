Shader "Custom/BlingBling" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_FlashColor ("Flash Color", Vector) = (1,1,1,1)
		_Angle ("Flash Angle", Range(0, 180)) = 45
		_Width ("Flash Width", Range(0, 1)) = 0.2
		_LoopTime ("Loop Time", Float) = 1
		_Interval ("Time Interval", Float) = 3
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}