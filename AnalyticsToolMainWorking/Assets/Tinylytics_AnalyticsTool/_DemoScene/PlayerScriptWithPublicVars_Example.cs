using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tinylytics.Examples {

/// <summary>
/// This is an example of a "player script" with some data exposed, to demonstrate and test recording these as analytics metrics.
/// </summary>
	public class PlayerScriptWithPublicVars_Example : MonoBehaviour {

		public int playerHealth = 55;
		public string playerName = "Hello World";
		public float playTime = 0;

		private void Update() {
			playTime += Time.deltaTime;
		}

	}
}