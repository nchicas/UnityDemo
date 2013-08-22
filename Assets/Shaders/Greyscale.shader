Shader "Grayscale" {
	
	Properties {
		_MainTex ("Texture", 2D) = ""
	}
	
	SubShader {
		Pass { //iPhone 3GS and later
			GLSLPROGRAM
			varying lowp vec2 uv;
			
			#ifdef VERTEX
			void main () {
				gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
				uv = gl_MultiTexCoord0.xy;
			}
			#endif
			
			#ifdef FRAGMENT
			uniform lowp sampler2D _MainTex;
			void main () {
				gl_FragColor = vec4(
					vec3(dot(texture2D(_MainTex, uv).rgb, vec3(.222, .707, .071)) ), 1);
			}
			#endif
			ENDGLSL
		}
	}
	
	SubShader {
		Pass { //pre-3GS devices, including the September 2009 8GB 
			Color (.389, .1465, .4645, .5)
			SetTexture[_MainTex] {Combine one - texture * primary alpha}
			SetTexture[_] {Combine previous Dot3 primary}
		}
	}

}