using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void OnApplicationPause(bool pause) {
		Debug.Log("paused");
		Tinylytics.AnalyticsManager.LogCustomMetric("OnPause", "Paused");
	}

	void OnApplicationQuit() {
		Debug.Log("quit");
		Tinylytics.AnalyticsManager.LogCustomMetric("OnQuit", "Quit");
	}
}
