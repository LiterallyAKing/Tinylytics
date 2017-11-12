using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("LoadNext", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadNext() {
		SceneManager.LoadScene(1);
	
	}

}
