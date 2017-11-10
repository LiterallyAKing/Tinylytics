using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using System;
using System.Reflection;

namespace BRAND_Analytics {
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

			System.Version version = Assembly.GetExecutingAssembly().GetName().Version;
			System.DateTime startDate = new System.DateTime(2000, 1, 1, 0, 0, 0);
			System.TimeSpan span = new System.TimeSpan(version.Build, 0, 0, version.Revision * 2);
			System.DateTime buildDate = startDate.Add(span);
			buildDateTime = buildDate;

		}



		public static void Test() {
			Debug.Log("Manager test() was called! My unique code is: " + UniqueURLCode);
			Instance.StartCoroutine(Instance.Upload());
			//StartCoroutine(Post("https://script.google.com/macros/s/AKfycbz7lcpTWIbW5l2km988pbY4zw2oIhgSWtSm8yuXgDSn9GwcN40/exec", "Question:"+ SystemInfo.deviceUniqueIdentifier.ToString() ));

		}

		public static string UniqueURLCode;
		public static System.DateTime buildDateTime;

		public static void SetUniqueURL(string code) {
			UniqueURLCode = code;
		}

		IEnumerator Upload() {


			Dictionary<string, string> test2 = new Dictionary<string, string>();
			test2.Add("UniqueID", SystemInfo.deviceUniqueIdentifier.ToString());
			test2.Add("deviceModel", SystemInfo.deviceModel.ToString());
			test2.Add("buildID", Application.buildGUID.ToString());
			test2.Add("buildTime", BuildtimeInfo.DateTimeString());
			//test2.Add("buildTime", buildDateTime.ToString());

			//time!!
			test2.Add("operatingSystem", SystemInfo.operatingSystem.ToString());
			test2.Add("operatingSystemFamily", SystemInfo.operatingSystemFamily.ToString());
			test2.Add("processorType", SystemInfo.processorType.ToString());
			test2.Add("systemMemorySize", SystemInfo.systemMemorySize.ToString());



			test2.Add("Test1", "Ibelongtotest1");
			test2.Add("Test2", "Test2please!");


			UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/" + UniqueURLCode + "/exec?", test2);


			yield return www.Send();


			if (www.isNetworkError) {
				Debug.Log(www.error);
			} else {
				Debug.Log("Form upload complete!");
			}
		}


		IEnumerator Post(string url, string bodyJsonString) {
			var request = new UnityWebRequest(url, "POST");
			byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
			request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
			request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			request.SetRequestHeader("Content-Type", "application/json");

			yield return request.Send();

			//Debug.Log("Status Code: " + request.responseCode);
		}

	}
}