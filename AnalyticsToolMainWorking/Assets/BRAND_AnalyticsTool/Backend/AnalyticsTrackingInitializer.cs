//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using System.IO;
//using System.Text;

namespace BRAND_Analytics {
	class BRAND_AnalyticsInitializer {


		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void OnBeforeSceneLoadRuntimeMethod() {
			//Debug.Log("Before first scene loaded");
			AnalyticsConfig storage = Resources.Load<AnalyticsConfig>("AnalyticsConfiguration");

			GameObject instance = GameObject.Instantiate(Resources.Load("AnalyticsManager")) as GameObject;
			BRAND_AnalyticsManager.SetUniqueURL(storage.uniqueURL);


		}


		//[RuntimeInitializeOnLoadMethod]
		//static void OnRuntimeMethodLoad() {
		//	Debug.Log("RuntimeMethodLoad: After first scene loaded");
		//}



	}
}