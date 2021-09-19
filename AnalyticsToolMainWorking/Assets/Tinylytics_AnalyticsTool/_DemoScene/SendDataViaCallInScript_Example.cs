using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tinylytics.Examples {

	/// <summary>
	/// This example shows how to call the Tinylytics AnalyticsManager directly via a static call, without using the widget.
	/// </summary>
	public class SendDataViaCallInScript_Example : MonoBehaviour {


		void Start() {
			Tinylytics.AnalyticsManager.LogCustomMetric("Current Month", System.DateTime.Now.Month.ToString());
		}

	}
}