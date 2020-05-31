Shader "Custom/PaletteSwapEquip"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color1 ("Color1", Color) = (1,1,1,1) 
        _Color2 ("Color2", Color) = (1,1,1,1)
         _Color3 ("Color3", Color) = (1,1,1,1) 
        _Color4 ("Color4", Color) = (1,1,1,1)
        _Color5 ("Color5", Color) = (1,1,1,1)
        _Color6 ("Color6", Color) = (1,1,1,1)
        _Color7 ("Color7", Color) = (1,1,1,1)
        _Color8 ("Color8", Color) = (1,1,1,1)
        _ColorPick1 ("CP1", float) = 0.1
        _ColorPick2 ("CP2", float) = 0.2
        _ColorPick3 ("CP3", float) = 0.3
        _ColorPick4 ("CP4", float) = 0.4
        _ColorPick5 ("CP5", float) = 0.5
        _ColorPick6 ("CP6", float) = 0.6
        _ColorPick7 ("CP7", float) = 0.7
        
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZWrite Off
Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _Color1;
            fixed4 _Color2;
            fixed4 _Color3;
            fixed4 _Color4;
            fixed4 _Color5;
            fixed4 _Color6;
            fixed4 _Color7;
            fixed4 _Color8;

            fixed _ColorPick1;
            fixed _ColorPick2;
            fixed _ColorPick3;
            fixed _ColorPick4;
            fixed _ColorPick5;
            fixed _ColorPick6;
            fixed _ColorPick7;


            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v) //once for each vertex to where its applied to
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                if(col.a == 0){
                    
                    return col;
                }
                if(col.r < _ColorPick1 ){
                    return _Color1;
                }
                else if(col.r < _ColorPick2){
                    return _Color2;
                }
                else if(col.r< _ColorPick3){
                    return _Color3;
                }
                else if(col.r< _ColorPick4){
                    return _Color4;
                }
                else if(col.r< _ColorPick5){
                    return _Color5;
                }
                else if(col.r< _ColorPick6){
                    return _Color6;
                }
                else if(col.r< _ColorPick7){
                    return _Color7;
                }
                
                else
                
                return _Color8;
            }
            ENDCG
        }
    }
}
