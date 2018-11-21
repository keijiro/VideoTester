Shader "Hidden/Tester"
{
    CGINCLUDE

    #include "UnityCG.cginc"

    int _FrameCount;

    half4 Fragment(v2f_img input) : SV_Target
    {
        float2 uv = input.uv;
        float t = _FrameCount / 60.0f;
        int c20 = (_FrameCount + 5) % 20;
        int c60 = (_FrameCount + 5) % 60;
#if ENABLE_FLASH
        return (c60 < 2 || c20 < 1) ^ (uv.x < frac(t));
#else
        return (uv.x < frac(t));
#endif
    }

    ENDCG

    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment Fragment
            ENDCG
        }
    }
}
