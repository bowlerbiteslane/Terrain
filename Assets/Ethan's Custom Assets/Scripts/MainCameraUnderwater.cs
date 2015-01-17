using UnityEngine;
using System.Collections;

public class MainCameraUnderwater : MonoBehaviour {

	//Hold the scenes 'out-of-water' settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;
	private Material noSkybox;

	public float underwaterFogDensity;

	void Awake(){
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
	}
	

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("MainCamera")) {
			Debug.Log ("MainCamera Entered the Water.");
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color (0, 0.4f, 0.7f, 0.6f);
			RenderSettings.fogDensity = underwaterFogDensity;
			RenderSettings.skybox = noSkybox;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("MainCamera")) {
			Debug.Log ("MainCamera Left the Water.");
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogDensity = defaultFogDensity;
			RenderSettings.skybox = defaultSkybox;
		}
	}
}
