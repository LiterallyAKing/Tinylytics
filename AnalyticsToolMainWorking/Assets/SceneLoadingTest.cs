using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingTest : MonoBehaviour {


	// called first
	void OnEnable() {
		Debug.Log("OnEnable called");
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	// called second
	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		Debug.Log("OnSceneLoaded: " + scene.name);
		Debug.Log(mode);
	}


	void OnSceneUnloaded(Scene scene) {
		Debug.Log("OnSceneUnloaded: " + scene.name);
	}



	// called when the game is terminated
	void OnDisable() {
		Debug.Log("OnDisable");
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}