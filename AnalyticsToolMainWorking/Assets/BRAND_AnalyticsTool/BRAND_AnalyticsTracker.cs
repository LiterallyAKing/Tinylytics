using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BRAND_Analytics;




namespace BRAND_Analytics {
	public class BRAND_AnalyticsTracker : MonoBehaviour {
		//https://docs.unity3d.com/Manual/JSONSerialization.html

		

		[SerializeField] public string metric_name;
		[SerializeField] public ValueProperty datatosend;

		[SerializeField] public AnalyticsTrigger trigger = new AnalyticsTrigger();

		[SerializeField] public AnalyticsAction payload = new AnalyticsAction();

		public void SetDataToSend(object data) {
			//data_to_send = data;
			//if (data_to_send != null) {
			//	Debug.Log(data_to_send.ToString());
			//}

			Debug.Log("I hold: " + datatosend.propertyValue);
		}

		public void TriggerEvent() {
			SendEvent();
		}

		void SendEvent() {
			//payload.Send();
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

			BRAND_AnalyticsManager.Test();


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

		

	}
}