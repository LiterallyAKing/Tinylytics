using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRAND_Analytics;




namespace BRAND_Analytics {
	public class BRAND_AnalyticsTracker : MonoBehaviour {
		//https://docs.unity3d.com/Manual/JSONSerialization.html

		

		[SerializeField] public string metric_name;
		[SerializeField] public ValueProperty datatosend;

		[SerializeField] public AnalyticsTrigger trigger;


		//TimeSinceGameStarted,
		//TotalTimePlayed

		void SendEvent() {
			//payload.Send();

			BRAND_AnalyticsManager.SendData(metric_name, datatosend.propertyValue, Application.isEditor);
		}



		void Awake() {
			if (trigger.triggerEvent == BRAND_Analytics.TriggerEvent.Awake) {
				SendEvent();
			}
		}

		void Start() {
			if (trigger.triggerEvent == BRAND_Analytics.TriggerEvent.Start) {
				SendEvent();
			}
		}

		void OnEnable() {
			if (trigger.triggerEvent == BRAND_Analytics.TriggerEvent.OnEnable) {
				SendEvent();
			}
		}

		void OnDisable() {
			if (trigger.triggerEvent == BRAND_Analytics.TriggerEvent.OnDisable) {
				SendEvent();
			}
		}

		void OnDestroy() {
			if (trigger.triggerEvent == BRAND_Analytics.TriggerEvent.OnDestroy) {
				SendEvent();
			}
		}

		public void OnCustomTrigger() {
			if (trigger.triggerEvent == BRAND_Analytics.TriggerEvent.CustomTriggerCall) {
				SendEvent();
			}
		}
		

	}
}