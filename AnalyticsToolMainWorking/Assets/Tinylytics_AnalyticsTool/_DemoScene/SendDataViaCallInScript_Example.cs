using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tinylytics.Examples {

	/// <summary>
	/// This example shows how to call the Tinylytics AnalyticsManager directly via a static call, without using the widget.
	/// </summary>
	public class SendDataViaCallInScript_Example : MonoBehaviour {

		public PlayerScriptWithPublicVars_Example playerData;

		void Start() {
			//EG: Sending the current month
			Tinylytics.AnalyticsManager.LogCustomMetric("Current Month", System.DateTime.Now.Month.ToString());
			//EG: Sending variable from a linked object
			Tinylytics.AnalyticsManager.LogCustomMetric("Player Name", playerData.playerName);
			//EG: Sending variable from a linked object, note numbers must be passed as strings
			Tinylytics.AnalyticsManager.LogCustomMetric("Player Health", playerData.playerHealth.ToString());
		}

	}
}