// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:1,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:1,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32740,y:33254,varname:node_2865,prsc:2|emission-8006-OUT,alpha-6626-OUT,voffset-6120-OUT;n:type:ShaderForge.SFN_TexCoord,id:4219,x:31981,y:33837,cmnt:Default coordinates,varname:node_4219,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:6120,x:32165,y:33837,varname:node_6120,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4219-UVOUT;n:type:ShaderForge.SFN_Color,id:8677,x:32018,y:32607,ptovrint:False,ptlb:node_8677,ptin:_node_8677,varname:node_8677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7193,x:32010,y:32786,varname:node_7193,prsc:2,tex:52a258bd6c4ecad478d5cc3569873e27,ntxv:0,isnm:False|UVIN-2955-UVOUT,TEX-2072-TEX;n:type:ShaderForge.SFN_Multiply,id:8006,x:32264,y:32724,varname:node_8006,prsc:2|A-8677-RGB,B-7193-RGB,C-6502-RGB;n:type:ShaderForge.SFN_TexCoord,id:314,x:30787,y:32660,varname:node_314,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:8503,x:30981,y:32630,varname:node_8503,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-314-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:1752,x:31152,y:32650,varname:node_1752,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8503-OUT;n:type:ShaderForge.SFN_ArcTan2,id:5611,x:31343,y:32678,varname:node_5611,prsc:2,attp:3|A-1752-G,B-1752-R;n:type:ShaderForge.SFN_Append,id:3199,x:31535,y:32669,varname:node_3199,prsc:2|A-5611-OUT,B-5611-OUT;n:type:ShaderForge.SFN_Rotator,id:2955,x:31753,y:32736,varname:node_2955,prsc:2|UVIN-3199-OUT;n:type:ShaderForge.SFN_TexCoord,id:6043,x:30937,y:33389,varname:node_6043,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector2,id:5169,x:30937,y:33583,varname:node_5169,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Distance,id:268,x:31210,y:33422,varname:node_268,prsc:2|A-6043-UVOUT,B-5169-OUT;n:type:ShaderForge.SFN_Power,id:5638,x:31776,y:33353,varname:node_5638,prsc:2|VAL-1016-OUT,EXP-5613-OUT;n:type:ShaderForge.SFN_Exp,id:5613,x:31761,y:33532,varname:node_5613,prsc:2,et:1|IN-1804-OUT;n:type:ShaderForge.SFN_Slider,id:1804,x:31494,y:33736,ptovrint:False,ptlb:node_1804,ptin:_node_1804,varname:node_1804,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:1.53915,max:3;n:type:ShaderForge.SFN_RemapRange,id:1016,x:31391,y:33430,varname:node_1016,prsc:2,frmn:0,frmx:0.5,tomn:0,tomx:0.6|IN-268-OUT;n:type:ShaderForge.SFN_Clamp01,id:6173,x:32041,y:33452,varname:node_6173,prsc:2|IN-5638-OUT;n:type:ShaderForge.SFN_Slider,id:801,x:31965,y:33650,ptovrint:False,ptlb:node_801,ptin:_node_801,varname:node_801,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:5;n:type:ShaderForge.SFN_Multiply,id:6626,x:32280,y:33499,varname:node_6626,prsc:2|A-6173-OUT,B-801-OUT;n:type:ShaderForge.SFN_Tex2d,id:6502,x:32071,y:33021,varname:node_6502,prsc:2,tex:52a258bd6c4ecad478d5cc3569873e27,ntxv:0,isnm:False|UVIN-2502-UVOUT,TEX-2072-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2072,x:31836,y:33030,ptovrint:False,ptlb:node_2072,ptin:_node_2072,varname:node_2072,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:52a258bd6c4ecad478d5cc3569873e27,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Rotator,id:2502,x:31711,y:32887,varname:node_2502,prsc:2|UVIN-3199-OUT,SPD-4008-OUT;n:type:ShaderForge.SFN_Vector1,id:4008,x:31620,y:32494,varname:node_4008,prsc:2,v1:0.3;proporder:8677-1804-801-2072;pass:END;sub:END;*/

Shader "Shader Forge/Shader5-post" {
    Properties {
        _node_8677 ("node_8677", Color) = (1,0,0,1)
        _node_1804 ("node_1804", Range(-1, 3)) = 1.53915
        _node_801 ("node_801", Range(0, 5)) = 2
        _node_2072 ("node_2072", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _node_8677;
            uniform float _node_1804;
            uniform float _node_801;
            uniform sampler2D _node_2072; uniform float4 _node_2072_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                v.vertex.xyz = float3((o.uv0*2.0+-1.0),0.0);
                o.pos = v.vertex;
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_1119 = _Time + _TimeEditor;
                float node_2955_ang = node_1119.g;
                float node_2955_spd = 1.0;
                float node_2955_cos = cos(node_2955_spd*node_2955_ang);
                float node_2955_sin = sin(node_2955_spd*node_2955_ang);
                float2 node_2955_piv = float2(0.5,0.5);
                float2 node_1752 = (i.uv0*2.0+-1.0).rg;
                float node_5611 = (1-abs(atan2(node_1752.g,node_1752.r)/3.14159265359));
                float2 node_3199 = float2(node_5611,node_5611);
                float2 node_2955 = (mul(node_3199-node_2955_piv,float2x2( node_2955_cos, -node_2955_sin, node_2955_sin, node_2955_cos))+node_2955_piv);
                float4 node_7193 = tex2D(_node_2072,TRANSFORM_TEX(node_2955, _node_2072));
                float node_2502_ang = node_1119.g;
                float node_2502_spd = 0.3;
                float node_2502_cos = cos(node_2502_spd*node_2502_ang);
                float node_2502_sin = sin(node_2502_spd*node_2502_ang);
                float2 node_2502_piv = float2(0.5,0.5);
                float2 node_2502 = (mul(node_3199-node_2502_piv,float2x2( node_2502_cos, -node_2502_sin, node_2502_sin, node_2502_cos))+node_2502_piv);
                float4 node_6502 = tex2D(_node_2072,TRANSFORM_TEX(node_2502, _node_2072));
                float3 emissive = (_node_8677.rgb*node_7193.rgb*node_6502.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,(saturate(pow((distance(i.uv0,float2(0.5,0.5))*1.2+0.0),exp2(_node_1804)))*_node_801));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
