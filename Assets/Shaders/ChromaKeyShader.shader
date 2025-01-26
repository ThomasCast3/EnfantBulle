Shader "Custom/ChromaKeyShader"
{
    Properties
    {
        _MainTex ("Video Texture", 2D) = "white" {} 
        _ChromaColor ("Chroma Key Color", Color) = (0, 1, 0, 1)  
        _Tolerance ("Tolerance", Range(0, 1)) = 0.3    
        _Alpha ("Alpha", Range(0, 1)) = 1.0    
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _ChromaColor;
            float _Tolerance;
            float _Alpha;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);
                float3 chromaDiff = abs(col.rgb - _ChromaColor.rgb);
                float diff = max(chromaDiff.r, max(chromaDiff.g, chromaDiff.b));
                if (diff < _Tolerance)
                {
                    col.a = 0;
                }
                else
                {
                    col.a = _Alpha;
                }

                return col;
            }
            ENDCG
        }
    }
}
