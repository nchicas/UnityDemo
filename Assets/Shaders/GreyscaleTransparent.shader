Shader "GrayscaleTransparent" {
	
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		 _TintColor ("Tint Color", Color) = (1,1,1,0)
	}

	SubShader {
		Tags {"Queue" = "Transparent" }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			Color (0.489, 0.265, 0.4645, 0.5)
			
			SetTexture[_MainTex] {Combine one - texture * primary, texture}
			SetTexture[_MainTex] {Combine previous Dot3 primary , texture}
			SetTexture[_MainTex] {
				constantColor [_TintColor]
				Combine constant * previous DOUBLE, texture
			}
		}
	}

	SubShader {
		Tags {"Queue" = "Transparent" }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			Color (0.489, 0.265, 0.4645, 0.5)
			
			SetTexture[_MainTex] {Combine one - texture * primary, texture}
			SetTexture[_MainTex] {Combine previous Dot3 primary , texture}
		}
	}
}	