using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;

public class postget_test : MonoBehaviour {

	//https://docs.google.com/spreadsheets/d/1neFvgY3qsBSiITkO6AAq7cNq25oGoxlm2NkO9tO9p9k/edit#gid=0
	//https://mashe.hawksey.info/2014/07/google-sheets-as-a-database-insert-with-apps-script-using-postget-methods-with-ajax-example/
	//https://gist.github.com/willpatera/ee41ae374d3c9839c2d6
	//http://daynebatten.com/2015/07/raw-data-google-analytics/
	//https://docs.unity3d.com/Manual/UnityWebRequest-SendingForm.html#UsingWWWForm
	//https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Post.html
	//http://html.net/tutorials/php/lesson10.php
	[Tooltip("The application identifier. Example value: com.company.app.")] public bool tooltiptest;
	void Start() {
		StartCoroutine(Upload());
		//StartCoroutine(Post("https://script.google.com/macros/s/AKfycbz7lcpTWIbW5l2km988pbY4zw2oIhgSWtSm8yuXgDSn9GwcN40/exec", "Question:"+ SystemInfo.deviceUniqueIdentifier.ToString() ));

	}

	IEnumerator Upload() {
		List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
		formData.Add(new MultipartFormDataSection("field1=Timestamp&field2=Question"));
		formData.Add(new MultipartFormFileSection(System.DateTime.Now.ToString(), "Data is here!"));


		//Debug.Log(formData);
		string test = "Question=" + SystemInfo.deviceUniqueIdentifier.ToString();

		Dictionary<string, string> test2 = new Dictionary<string, string>();
		test2.Add("UniqueID", SystemInfo.deviceUniqueIdentifier.ToString());
		test2.Add("deviceModel", SystemInfo.deviceModel.ToString());
		test2.Add("buildID", Application.buildGUID.ToString());
		//test2.Add("buildTime", BuildtimeInfo.DateTimeString());
		//time!!
		test2.Add("operatingSystem", SystemInfo.operatingSystem.ToString());
		test2.Add("operatingSystemFamily", SystemInfo.operatingSystemFamily.ToString());
		test2.Add("processorType", SystemInfo.processorType.ToString());
		test2.Add("systemMemorySize", SystemInfo.systemMemorySize.ToString());



		test2.Add("Test1", "Ibelongtotest1");
		test2.Add("Test2", "Test2please!");


		UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbz7lcpTWIbW5l2km988pbY4zw2oIhgSWtSm8yuXgDSn9GwcN40/exec?", test2);
		//UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbz7lcpTWIbW5l2km988pbY4zw2oIhgSWtSm8yuXgDSn9GwcN40/exec?Question=" + test, "?Question2=This is from Unity");
		//UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbz7lcpTWIbW5l2km988pbY4zw2oIhgSWtSm8yuXgDSn9GwcN40/exec?","Question=" + test);
		//UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/u/0/s/AKfycbz7lcpTWIbW5l2km988pbY4zw2oIhgSWtSm8yuXgDSn9GwcN40/exec?", "Question=" + test);

		//UnityWebRequest test = UnityWebRequest.Post(

		//www.SetRequestHeader("Content-Type", "application/json");

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

		Debug.Log("Status Code: " + request.responseCode);
	}


	// Update is called once per frame
	void Update() {

	}
	//https://script.google.com/macros/s/AKfycbxYEfYd2PhxYy808F47EatO5nW3b4FEhOV_KOVkqFrSJ3RdlD0/exec

}
