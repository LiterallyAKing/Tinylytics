using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using System;
using System.Reflection;

namespace BRAND_Analytics {

	public class DataPacket {

		public Dictionary<string, string> data = new Dictionary<string, string>();

		
		public DataPacket(string metricname, string newdata, bool debugmode) {

			//All the standard fields
			if (debugmode) {
				data.Add("TestingStatus", "DebugMode");
			} else {
				data.Add("TestingStatus", "");
			}
			data.Add("Player_UniqueID", SystemInfo.deviceUniqueIdentifier.ToString());
			data.Add("Player_deviceModel", SystemInfo.deviceModel.ToString());
			data.Add("Player_OS", SystemInfo.operatingSystem.ToString());
			data.Add("Player_OSFamily", SystemInfo.operatingSystemFamily.ToString());
			//data.Add("Player_processorType", SystemInfo.processorType.ToString());
			data.Add("Player_SystemMemory", SystemInfo.systemMemorySize.ToString());
			data.Add("Build_UniqueID", Application.buildGUID.ToString());
			data.Add("Build_DateTime", BuildtimeInfo.DateTimeString());

			//new data
			data.Add("MetricName", metricname);
			data.Add("MetricData", newdata);
		}

	}


	public class BRAND_AnalyticsManager : MonoBehaviour {

		private static BRAND_AnalyticsManager _instance;

		public static BRAND_AnalyticsManager Instance { get { return _instance; } }

		private void Awake() {
			if (_instance != null && _instance != this) {
				Destroy(this.gameObject);
			} else {
				_instance = this;
				DontDestroyOnLoad(this);
			}
		}




		public static string UniqueURLCode;

		public static void SetUniqueURL(string code) {
			UniqueURLCode = code;
		}


		public static void SendData(string metricname, string data, bool isdebug) {
			DataPacket tosend = new DataPacket(metricname, data, isdebug);

			Instance.StartCoroutine(Instance.PostData(tosend));
		}


		IEnumerator PostData(DataPacket datatosend) {
			UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/" + UniqueURLCode + "/exec?", datatosend.data);

			yield return www.Send();

			if (www.isNetworkError) {
				Debug.Log(www.error);
			} else {
				Debug.Log("Form upload complete!");
			}
		}
		

		//IEnumerator Post(string url, string bodyJsonString) {
		//	var request = new UnityWebRequest(url, "POST");
		//	byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
		//	request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
		//	request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		//	request.SetRequestHeader("Content-Type", "application/json");

		//	yield return request.Send();

		//	//Debug.Log("Status Code: " + request.responseCode);
		//}

	}
}