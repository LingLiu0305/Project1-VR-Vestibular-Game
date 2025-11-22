Shader "Custom/GlassWithZWrite_Emission"
{
    Properties
    {
        _Color ("Tint", Color) = (1,1,1,0.2)
        _MainTex ("Texture", 2D) = "white" {}
        _EmissionColor ("Emission Color", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _EmissionColor;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv);
                fixed4 col = tex * _Color;
                col.rgb += _EmissionColor.rgb;
                return col;
            }
            ENDCG
        }
    }
}
