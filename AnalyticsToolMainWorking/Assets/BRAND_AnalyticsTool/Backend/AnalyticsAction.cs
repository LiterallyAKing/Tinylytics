using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BRAND_Analytics {
	[Serializable]
	public class AnalyticsAction {
		// Properties for Lifecycle
		[SerializeField]
		DataToSend _tosendcategory;
		public DataToSend toSendCategory {
			get {
				return _tosendcategory;
			}
		}


	}


	[Serializable]
	public enum DataToSend {
		None = 0,
		CustomInt, CustomString, CustomFloat,
		FromAScript,
		TimeSinceGameStarted,
		TotalTimePlayed
	}
}
