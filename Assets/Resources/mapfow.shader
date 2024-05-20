Shader "Ninjutsu Games/Map FOW" {
	Properties {
		_Color ("_Color", Vector) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Revealed ("Revealed", 2D) = "white" {}
		_Hidden ("Hidden", 2D) = "white" {}
		_Mask ("Culling Mask", 2D) = "white" {}
		_MaskColor ("Discard Color", Vector) = (1,1,1,1)
		_AlphaMultiplier ("Alpha Multiplier", Float) = 2
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}