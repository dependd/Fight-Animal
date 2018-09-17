// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/Chromakey" {
        Properties{
            _MainTex("Base ( RGB ) Trans ( A )", 2D) = "white" { }
            _MaxHue("Max Hue", Range(0, 1)) = 1
            _MinHue("Min Hue", Range(0, 1)) = 1
            _MaxSaturation("Max Saturation", Range(0, 1)) = 1
            _MinSaturation("Min Saturation", Range(0, 1)) = 1
            _MaxValue("Max Value", Range(0, 1)) = 1
            _MinValue("Min Value", Range(0, 1)) = 1

        }
        SubShader{
                Tags{ "Queue" = "Overlay+1" "RenderType" = "Overlay" }
                LOD 200
                Pass{
                    Lighting Off
                    ZWrite Off
                    Ztest Always
                    Blend SrcAlpha OneMinusSrcAlpha

                    CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #include "UnityCG.cginc"

                    sampler2D _MainTex;
                    float _MaxHue;
                    float _MinHue;
                    float _MaxSaturation;
                    float _MinSaturation;
                    float _MaxValue;
                    float _MinValue;

                    struct v2f {
                        float4 pos : SV_POSITION;
                        half2 uv : TEXCOORD0;
                        float2 uv_MainTex : TEXCOORD0;
                    };

                    //  RGB値をHSV値に変換
                    float3 RGBtoHSV( float3 rgb) {
                        float hue = 0;
                        float minValue = min(rgb.r, min(rgb.g, rgb.b));
                        float maxValue = max(rgb.r, max(rgb.g, rgb.b));
                        if (minValue == maxValue) {
                            hue = 0;
                        }
                        else if (minValue == rgb.b) {
                            hue = 60 * (rgb.g - rgb.r) / (maxValue - minValue) + 60;
                        }
                        else if (minValue == rgb.r) {
                            hue = 60 * (rgb.b - rgb.g) / (maxValue - minValue) + 180;
                        }
                        else if (minValue == rgb.g) {
                            hue = 60 * (rgb.r - rgb.b) / (maxValue - minValue) + 300;
                        }
                        hue /= 360;
                        float value = maxValue;
                        float saturation = maxValue - minValue;
                        float3 hsv = float3( hue, saturation, value ); 
                        return hsv;
                    }

                    v2f vert( appdata_img v ) {
                        v2f o;
                        o.pos = UnityObjectToClipPos (v.vertex);
                        o.uv = v.texcoord;
                        return o;
                    }

                    //  HSV値で判定
                    float4 frag( v2f i ) : COLOR0 {
                        float3 colors = tex2D( _MainTex, i.uv_MainTex ).rgb;
                        float3 hsvcolor = RGBtoHSV(colors);
                        if (hsvcolor.r >= _MinHue && hsvcolor.r <= _MaxHue) {
                            if (hsvcolor.g >= _MinSaturation && hsvcolor.g <= _MaxSaturation) {
                                if (hsvcolor.b >= _MinValue && hsvcolor.b <= _MaxValue) {
                                    discard;
                                }
                            }
                        }

                        return float4(colors, 1.0);
                    }
                    ENDCG
            }
    }
    FallBack "Tranparent/Diffuse"
}