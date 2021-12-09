Shader "Hidden/Generator"
{
    CGINCLUDE

    #include "UnityCG.cginc"

    void Vertex(float4 position : POSITION,
                float2 texCoord : TEXCOORD0,
                out float4 outPosition : SV_Position,
                out float2 outTexCoord : TEXCOORD0)
    {
        outPosition = UnityObjectToClipPos(position);
        outTexCoord = texCoord;
    }

    float4 Fragment(float4 position : SV_Position,
                    float2 texCoord : TEXCOORD0) : SV_Target
    {
        uint p = texCoord.x * _ScreenParams.x;
        bool sw = p & 2;
        return lerp(float4(1, 0, 0, 1), float4(0, 0, 1, 1), sw);
    }

    ENDCG

    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Pass
        {
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            ENDCG
        }
    }
}
