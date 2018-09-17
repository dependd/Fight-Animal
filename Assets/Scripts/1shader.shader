
Shader "Onoty3D/ChromaKey" {
	Properties{
		_KeyColor("Key Color", Color) = (0,1,0)
		_Near("Near", Range(0, 2)) = 0.2
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	}

	SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200

		CGPROGRAM
			#pragma surface surf Lambert alpha

			sampler2D _MainTex;
			fixed3 _KeyColor;
			fixed _Near;

			struct Input {
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutput o) {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
				clip(distance(_KeyColor, c) - _Near);
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}
		ENDCG
	}

	Fallback "Transparent/Diffuse"
}