Shader "HackDay/ConnectionLight"
{
	Properties
	{
		_Color1 ("Color1", Color) = (1, 1, 1, 1)
		_Color2 ("Color2", Color) = (1, 1, 1, 1)
		_Color3 ("Color3", Color) = (1, 1, 1, 1)
		_Color4 ("Color4", Color) = (1, 1, 1, 1)
		_Color5 ("Color5", Color) = (1, 1, 1, 1)
        
	}
	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
                #include "UnityCG.cginc"

				struct appdata_t
				{
					float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float4 vertex : SV_POSITION;
                    float2 uv : TEXCOORD0;
				};
				
                float4 _Color1;
                float4 _Color2;
                float4 _Color3;
                float4 _Color4;
                float4 _Color5;

				v2f vert(appdata_t i)
				{
					v2f o;

					o.vertex = UnityObjectToClipPos(i.vertex);
                    o.uv = i.uv;
					
                    return o;
				}

                float4 Strand(in float2 uv, in float3 color, in float hoffset, in float hscale, in float vscale, in float width, in float timescale)
                {
                    float glow =0.04;
                    float curve = sin(fmod(uv.x * hscale / 100.0 * 1000.0 + _Time.y * timescale + hoffset, UNITY_TWO_PI)) * 0.25 * vscale + 0.5;
                    curve = smoothstep(uv.y - width, uv.y, curve) - smoothstep(uv.y, uv.y + width, curve);

                    float i = clamp((glow * curve + curve), 0.0, 1.0) ;
                    return float4(i * color, i);
                }

				fixed4 frag(v2f IN) : SV_Target
				{
                    float timescale = 3.0;
                    float2 uv = IN.uv;

                    float4 c = float4(0, 0, 0, 0);

                    float4 color1 = Strand(uv,     _Color1.rgb,    79.34,  0.5,    0.5,    0.3,    10.0 * timescale);
                    float4 color2 = Strand(uv,     _Color2.rgb,    64.5,   2.5,    0.2,    0.32,    10.3 * timescale);
                    float4 color3 = Strand(uv,     _Color3.rgb,    73.5,   2.3,    0.19,   0.315,   8.0 * timescale);
                    float4 color4 = Strand(uv,     _Color4.rgb,    92.45,  2.6,    0.14,   0.308,   12.0 * timescale);
                    float4 color5 = Strand(uv,     _Color5.rgb,    72.34,  2.1,    0.13,   0.323,   14.0 * timescale);

                    c = color1;
                    // c = float4(color2.rgb + (1 - color2.a) * c.rgb, color2.a);
                    // c = float4(color3.rgb + (1 - color3.a) * c.rgb, color3.a);
                    // c = float4(color4.rgb + (1 - color4.a) * c.rgb, color4.a);
                    // c = float4(color5.rgb + (1 - color5.a) * c.rgb, color5.a);

					return float4(c.r, c.g, c.b, 1.0);
				}
			ENDCG
		}
	}
}
