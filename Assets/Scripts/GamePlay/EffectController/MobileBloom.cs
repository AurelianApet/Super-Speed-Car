using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Mobile Bloom V2")]
public class MobileBloom : MonoBehaviour
{
		public float intensity = 0.7f;
		public float threshhold = 0.75f;
		public float blurWidth = 1.0f;
//		public bool extraBlurry = false;
	
		// image effects materials for internal use
	
		public Material bloomMaterial = null;
		private RenderTexture tempRtA = null;
		private RenderTexture tempRtB = null;

		//
		private bool supported = false;
		Vector4 intensityVector;

		//
		float oneOverW;
		float oneOverH;
		float tempBlurWidth;

		void OnEnable ()
		{		
				if (!tempRtA) {
						tempRtA = new RenderTexture (256, 128, 0);
						tempRtA.hideFlags = HideFlags.DontSave;		
				}
				if (!tempRtB) {
						tempRtB = new RenderTexture (256, 128, 0);	
						tempRtB.hideFlags = HideFlags.DontSave;
				}
		
				supported = (SystemInfo.supportsImageEffects && SystemInfo.supportsRenderTextures && bloomMaterial.shader.isSupported);
		
				intensityVector = new Vector4 (0.0f, 0.0f, threshhold, intensity / (1.0f - threshhold));		
				tempBlurWidth = 4 * blurWidth;
		}
	
		void OnDestroy ()
		{
				if (tempRtA) {
						DestroyImmediate (tempRtA);
						tempRtA = null;
				}	
				if (tempRtB) {
						DestroyImmediate (tempRtB);
						tempRtB = null;
				}	
		}
	
		void OnRenderImage (RenderTexture source, RenderTexture destination)
		{						
				if (tempRtA != null && tempRtB != null) {
						if (supported == false) {
								return;
						}
		
						// prepare data
		
						bloomMaterial.SetVector ("_Parameter", intensityVector);	
		
						// ds & blur
		
						oneOverW = 1.0f / source.width;
						oneOverH = 1.0f / source.height;
		
						bloomMaterial.SetVector ("_OffsetsA", new Vector4 (1.5f * oneOverW, 1.5f * oneOverH, -1.5f * oneOverW, 1.5f * oneOverH));	
						bloomMaterial.SetVector ("_OffsetsB", new Vector4 (-1.5f * oneOverW, -1.5f * oneOverH, 1.5f * oneOverW, -1.5f * oneOverH));	

						tempRtB.DiscardContents ();
						Graphics.Blit (source, tempRtB, bloomMaterial, 1);
		
						oneOverW *= tempBlurWidth;
						oneOverH *= tempBlurWidth;
		
						bloomMaterial.SetVector ("_OffsetsA", new Vector4 (1.5f * oneOverW, 0.0f, -1.5f * oneOverW, 0.0f));	
						bloomMaterial.SetVector ("_OffsetsB", new Vector4 (0.5f * oneOverW, 0.0f, -0.5f * oneOverW, 0.0f));	

						tempRtA.DiscardContents ();
						Graphics.Blit (tempRtB, tempRtA, bloomMaterial, 2);
		
						bloomMaterial.SetVector ("_OffsetsA", new Vector4 (0.0f, 1.5f * oneOverH, 0.0f, -1.5f * oneOverH));	
						bloomMaterial.SetVector ("_OffsetsB", new Vector4 (0.0f, 0.5f * oneOverH, 0.0f, -0.5f * oneOverH));	

						tempRtB.DiscardContents ();
						Graphics.Blit (tempRtA, tempRtB, bloomMaterial, 2);
		
//				if (extraBlurry) {
//						bloomMaterial.SetVector ("_OffsetsA", new Vector4 (1.5f * oneOverW, 0.0f, -1.5f * oneOverW, 0.0f));	
//						bloomMaterial.SetVector ("_OffsetsB", new Vector4 (0.5f * oneOverW, 0.0f, -0.5f * oneOverW, 0.0f));	
//						Graphics.Blit (tempRtB, tempRtA, bloomMaterial, 2);
//			
//						bloomMaterial.SetVector ("_OffsetsA", new Vector4 (0.0f, 1.5f * oneOverH, 0.0f, -1.5f * oneOverH));	
//						bloomMaterial.SetVector ("_OffsetsB", new Vector4 (0.0f, 0.5f * oneOverH, 0.0f, -0.5f * oneOverH));	
//						Graphics.Blit (tempRtA, tempRtB, bloomMaterial, 2);		
//				}
		
						// bloomMaterial
		
						bloomMaterial.SetTexture ("_Bloom", tempRtB);
						Graphics.Blit (source, destination, bloomMaterial, 0);
				}
		}
}
