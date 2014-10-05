Shader "Cone/Gradient" {
	Properties {
		_TopColor ("Top Color", Color) = (1,1,1,1)
		_BottomColor ("Bottom Color", Color) = (0,0,0,0)
	}
	
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			uniform float4 _TopColor;
			uniform float4 _BottomColor;

            struct vertOut {
                float4 pos:SV_POSITION;
                float4 scrPos;
            };

            vertOut vert(appdata_base v) {
                vertOut o;
                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                o.scrPos = ComputeScreenPos(o.pos);
                return o;
            }

            fixed4 frag(vertOut i) : COLOR0 {
                float2 wcoord = (i.scrPos.xy/i.scrPos.w);
                fixed4 color;

                color = wcoord.y * _TopColor + (1 - wcoord.y) * _BottomColor;
                
                return color;
            }

            ENDCG
        }
    }
}