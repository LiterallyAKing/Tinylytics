using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTesting_LoadNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("LoadNext", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadNext() {
		SceneManager.LoadScene(1);
	
	}

}
