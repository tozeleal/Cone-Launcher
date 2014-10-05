Shader "Cone/Background" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			
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
                float2 wcoord = i.scrPos.xy / i.scrPos.w;
                
                return tex2D(_MainTex, wcoord);
            }

            ENDCG
        }
    }
}