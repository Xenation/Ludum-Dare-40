// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33293,y:32692,varname:node_4013,prsc:2|diff-4584-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32307,y:32434,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9563,x:31405,y:32545,varname:_NoiseCol,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1062-OUT,TEX-6073-TEX;n:type:ShaderForge.SFN_Multiply,id:8353,x:32516,y:32645,varname:node_8353,prsc:2|A-1304-RGB,B-2901-OUT,C-2887-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:8138,x:30471,y:32403,varname:node_8138,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:8558,x:30667,y:32393,varname:node_8558,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-8138-XYZ;n:type:ShaderForge.SFN_Multiply,id:1062,x:31108,y:32345,varname:node_1062,prsc:2|A-7596-OUT,B-8558-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7596,x:30884,y:32279,ptovrint:False,ptlb:ScaleCol,ptin:_ScaleCol,varname:_ScaleCol,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Power,id:7288,x:31588,y:32703,varname:node_7288,prsc:2|VAL-9563-RGB,EXP-6221-OUT;n:type:ShaderForge.SFN_Vector1,id:6221,x:31405,y:32753,varname:node_6221,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:8571,x:31764,y:32703,varname:node_8571,prsc:2|IN-7288-OUT;n:type:ShaderForge.SFN_Round,id:6498,x:32100,y:32703,varname:node_6498,prsc:2|IN-3990-OUT;n:type:ShaderForge.SFN_Divide,id:2901,x:32288,y:32645,varname:node_2901,prsc:2|A-6498-OUT,B-2791-OUT;n:type:ShaderForge.SFN_Multiply,id:3990,x:31936,y:32641,varname:node_3990,prsc:2|A-2791-OUT,B-8571-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2791,x:31764,y:32555,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:_Ramp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Tex2dAsset,id:6073,x:31180,y:32629,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:_Noise,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2523,x:31252,y:32919,varname:_node_2523,prsc:2,tex:3bad7187c2627d249886568595a5806e,ntxv:0,isnm:False|UVIN-6800-OUT,TEX-6522-TEX;n:type:ShaderForge.SFN_Step,id:3399,x:31934,y:32981,varname:node_3399,prsc:2|A-1923-OUT,B-3815-OUT;n:type:ShaderForge.SFN_Vector1,id:3815,x:31771,y:33001,varname:node_3815,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:4334,x:31771,y:33109,varname:node_4334,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Step,id:2258,x:31934,y:33153,varname:node_2258,prsc:2|A-1923-OUT,B-4334-OUT;n:type:ShaderForge.SFN_Multiply,id:2887,x:32318,y:33079,varname:node_2887,prsc:2|A-2501-OUT,B-2258-OUT;n:type:ShaderForge.SFN_OneMinus,id:2501,x:32130,y:33007,varname:node_2501,prsc:2|IN-3399-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5625,x:30667,y:32605,ptovrint:False,ptlb:ScaleCracks,ptin:_ScaleCracks,varname:_ScaleCracks,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:6800,x:30891,y:32557,varname:node_6800,prsc:2|A-8558-OUT,B-5625-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6522,x:30895,y:33103,ptovrint:False,ptlb:CracksNoise,ptin:_CracksNoise,varname:_CracksNoise,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3bad7187c2627d249886568595a5806e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4155,x:31264,y:33125,varname:_node_4155,prsc:2,tex:3bad7187c2627d249886568595a5806e,ntxv:0,isnm:False|UVIN-7121-UVOUT,TEX-6522-TEX;n:type:ShaderForge.SFN_Panner,id:7121,x:31101,y:33125,varname:node_7121,prsc:2,spu:0.01,spv:0.01|UVIN-6800-OUT;n:type:ShaderForge.SFN_Add,id:6266,x:31431,y:33047,varname:node_6266,prsc:2|A-2523-R,B-4155-R;n:type:ShaderForge.SFN_RemapRange,id:1923,x:31593,y:33047,varname:node_1923,prsc:2,frmn:0,frmx:2,tomn:0,tomx:1|IN-6266-OUT;n:type:ShaderForge.SFN_OneMinus,id:7442,x:32516,y:32837,varname:node_7442,prsc:2|IN-2887-OUT;n:type:ShaderForge.SFN_Color,id:8070,x:32516,y:32997,ptovrint:False,ptlb:ColdColor,ptin:_ColdColor,varname:_ColdColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2969,x:32717,y:32837,varname:node_2969,prsc:2|A-7442-OUT,B-8070-RGB,C-2907-RGB;n:type:ShaderForge.SFN_Add,id:4263,x:32893,y:32697,varname:node_4263,prsc:2|A-8353-OUT,B-2969-OUT;n:type:ShaderForge.SFN_Tex2d,id:2907,x:32505,y:33299,varname:_node_2907,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8562-UVOUT,TEX-6073-TEX;n:type:ShaderForge.SFN_Panner,id:8562,x:32318,y:33299,varname:node_8562,prsc:2,spu:-0.01,spv:-0.01|UVIN-1617-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1617,x:32144,y:33299,varname:node_1617,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:4584,x:33081,y:32697,varname:node_4584,prsc:2,frmn:0,frmx:1,tomn:0.01,tomx:1|IN-4263-OUT;proporder:1304-7596-2791-6073-5625-6522-8070;pass:END;sub:END;*/

Shader "Shader Forge/lavaShader" {
    Properties {
        _Color ("Color", Color) = (1,0,0,1)
        _ScaleCol ("ScaleCol", Float ) = 0.5
        _Ramp ("Ramp", Float ) = 10
        _Noise ("Noise", 2D) = "white" {}
        _ScaleCracks ("ScaleCracks", Float ) = 1
        _CracksNoise ("CracksNoise", 2D) = "white" {}
        _ColdColor ("ColdColor", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _ScaleCol;
            uniform float _Ramp;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _ScaleCracks;
            uniform sampler2D _CracksNoise; uniform float4 _CracksNoise_ST;
            uniform float4 _ColdColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float2 node_8558 = i.posWorld.rgb.rb;
                float2 node_1062 = (_ScaleCol*node_8558);
                float4 _NoiseCol = tex2D(_Noise,TRANSFORM_TEX(node_1062, _Noise));
                float2 node_6800 = (node_8558*_ScaleCracks);
                float4 _node_2523 = tex2D(_CracksNoise,TRANSFORM_TEX(node_6800, _CracksNoise));
                float4 node_5448 = _Time + _TimeEditor;
                float2 node_7121 = (node_6800+node_5448.g*float2(0.01,0.01));
                float4 _node_4155 = tex2D(_CracksNoise,TRANSFORM_TEX(node_7121, _CracksNoise));
                float node_1923 = ((_node_2523.r+_node_4155.r)*0.5+0.0);
                float node_2887 = ((1.0 - step(node_1923,0.1))*step(node_1923,0.2));
                float2 node_8562 = (i.uv0+node_5448.g*float2(-0.01,-0.01));
                float4 _node_2907 = tex2D(_Noise,TRANSFORM_TEX(node_8562, _Noise));
                float3 diffuseColor = (((_Color.rgb*(round((_Ramp*saturate(pow(_NoiseCol.rgb,1.0))))/_Ramp)*node_2887)+((1.0 - node_2887)*_ColdColor.rgb*_node_2907.rgb))*0.99+0.01);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _ScaleCol;
            uniform float _Ramp;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _ScaleCracks;
            uniform sampler2D _CracksNoise; uniform float4 _CracksNoise_ST;
            uniform float4 _ColdColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_8558 = i.posWorld.rgb.rb;
                float2 node_1062 = (_ScaleCol*node_8558);
                float4 _NoiseCol = tex2D(_Noise,TRANSFORM_TEX(node_1062, _Noise));
                float2 node_6800 = (node_8558*_ScaleCracks);
                float4 _node_2523 = tex2D(_CracksNoise,TRANSFORM_TEX(node_6800, _CracksNoise));
                float4 node_7349 = _Time + _TimeEditor;
                float2 node_7121 = (node_6800+node_7349.g*float2(0.01,0.01));
                float4 _node_4155 = tex2D(_CracksNoise,TRANSFORM_TEX(node_7121, _CracksNoise));
                float node_1923 = ((_node_2523.r+_node_4155.r)*0.5+0.0);
                float node_2887 = ((1.0 - step(node_1923,0.1))*step(node_1923,0.2));
                float2 node_8562 = (i.uv0+node_7349.g*float2(-0.01,-0.01));
                float4 _node_2907 = tex2D(_Noise,TRANSFORM_TEX(node_8562, _Noise));
                float3 diffuseColor = (((_Color.rgb*(round((_Ramp*saturate(pow(_NoiseCol.rgb,1.0))))/_Ramp)*node_2887)+((1.0 - node_2887)*_ColdColor.rgb*_node_2907.rgb))*0.99+0.01);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
