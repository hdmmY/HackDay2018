Shader "HackDay/ConnectionLight"
{
	Properties
	{
		_Color1 ("Color1", Color) = (1, 1, 1, 1)
		_Color2 ("Color2", Color) = (1, 1, 1, 1)
		_Color3 ("Color3", Color) = (1, 1, 1, 1)
		_Color4 ("Color4", Color) = (1, 1, 1, 1)
		_Color5 ("Color5", Color) = (1, 1, 1, 1)
        _Alpha ("Alpha", Range(0 , 1)) = 1   
        _ScaleX ("ScaleX", Float) = 1
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
                float _Alpha;
                float _ScaleX;

				v2f vert(appdata_t i)
				{
					v2f o;

					o.vertex = UnityObjectToClipPos(i.vertex);
                    o.uv = i.uv;
					
                    return o;
				}

                float4 Strand(in float2 uv, in float3 color, in float hoffset, in float hscale, in float vscale, in float width, in float timescale)
                {
                    float glow = 0.04;
                    float curve = sin(fmod(uv.x * hscale / 100.0 * 1000.0 + _Time.y * timescale + hoffset, UNITY_TWO_PI)) * 0.25 * vscale + 0.5;
                    curve = smoothstep(uv.y - width, uv.y, curve) - smoothstep(uv.y, uv.y + width, curve);

                    float i = clamp((glow * curve + curve), 0.0, 1.0) ;
                    return float4(i * color, i);
                }

				fixed4 frag(v2f IN) : SV_Target
				{
                    float timescale = 3.0;
                    float2 uv = IN.uv;
                    uv.x *= _ScaleX;

                    float4 c = float4(0, 0, 0, 0);
                    c = Strand(uv,     _Color1.rgb,    79.34,   0.5,    0.1,        0.25,    12.0 * timescale);
                    c += Strand(uv,     _Color2.rgb,    120.34,  1.1,    0.62,       0.08,    3.0 * timescale);
                    c += Strand(uv,     _Color3.rgb,    380.34,  1.7,    1.5,       0.08,    1.0 * timescale);
                    c += Strand(uv,     _Color4.rgb,    180.34,  1.4,    1,       0.08,    2.0 * timescale);
                    c += Strand(uv,     _Color5.rgb,    450.34,  2.0,    0.8,       0.10,    2.0 * timescale);
                    

					return float4(c.r, c.g, c.b, c.a * _Alpha);
				}
			ENDCG
		}
	}
}
