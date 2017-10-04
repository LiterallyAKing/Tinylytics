using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsBase : MonoBehaviour {

//	[Tooltip("Automatically send a launch event when the game starts up.")]
//	public bool sendLaunchEvent = false;

//	public static AnalyticsBase instance = null;
//	private bool initialized = false;

//	private AnalyticsBase mpTracker = new GoogleAnalyticsMPV3();


//	private string screenRes;
//	private string clientId;

//	private bool startSessionOnNextHit = false;
//	private bool endSessionOnNextHit = false;

//	void Awake() {
//		InitializeTracker();
//		if (sendLaunchEvent) {
//			LogEvent("Google Analytics", "Auto Instrumentation", "Game Launch", 0);
//		}

//	}

//	private void InitializeTracker() {

//		if (String.IsNullOrEmpty(trackingCode)) {
//			Debug.Log("No tracking code set for 'Other' platforms - hits will not be set");
//			trackingCodeSet = false;
//			return;
//		}

//		if (!initialized) {
//			instance = this;
//			DontDestroyOnLoad(instance);

//			Debug.Log("Initializing Google Analytics 0.2.");
//#if UNITY_ANDROID && !UNITY_EDITOR
//      androidTracker.SetTrackingCode(androidTrackingCode);
//      androidTracker.SetAppName(productName);
//      androidTracker.SetBundleIdentifier(bundleIdentifier);
//      androidTracker.SetAppVersion(bundleVersion);
//      androidTracker.SetDispatchPeriod(dispatchPeriod);
//      androidTracker.SetSampleFrequency(sampleFrequency);
//      androidTracker.SetLogLevelValue(logLevel);
//      androidTracker.SetAnonymizeIP(anonymizeIP);
//      androidTracker.SetAdIdCollection(enableAdId);
//      androidTracker.SetDryRun(dryRun);
//      androidTracker.InitializeTracker();
//#else
//			mpTracker.SetTrackingCode(otherTrackingCode);
//			mpTracker.SetBundleIdentifier(bundleIdentifier);
//			mpTracker.SetAppName(productName);
//			mpTracker.SetAppVersion(bundleVersion);
//			mpTracker.SetLogLevelValue(logLevel);
//			mpTracker.SetAnonymizeIP(anonymizeIP);
//			mpTracker.SetDryRun(dryRun);
//			mpTracker.InitializeTracker();
//#endif
//			initialized = true;
//			SetOnTracker(Fields.DEVELOPER_ID, "GbOCSs");
//		}
//		screenRes = Screen.width + "x" + Screen.height;
//		clientId = SystemInfo.deviceUniqueIdentifier;

//	}
//	public void SetTrackerVal(Field field, object value) {
//		trackerValues[field] = value;
//	}
//	internal void StartSession() {
//		startSessionOnNextHit = true;
//	}

//	internal void StopSession() {
//		endSessionOnNextHit = true;
//	}

//	public static AnalyticsBase getInstance() {
//		return instance;
//	}


//	private void SendGaHitWithMeasurementProtocol(string url) {
//		if (String.IsNullOrEmpty(url)) {
//			if (GoogleAnalyticsV4.belowThreshold(logLevel, GoogleAnalyticsV4.DebugMode.WARNING)) {
//				Debug.Log("No tracking code set for 'Other' platforms - hit will not be sent.");
//			}
//			return;
//		}
//		if (dryRun || optOut) {
//			if (GoogleAnalyticsV4.belowThreshold(logLevel, GoogleAnalyticsV4.DebugMode.WARNING)) {
//				Debug.Log("Dry run or opt out enabled - hits will not be sent.");
//			}
//			return;
//		}
//		if (startSessionOnNextHit) {
//			url += AddOptionalMPParameter(Fields.SESSION_CONTROL, "start");
//			startSessionOnNextHit = false;
//		} else if (endSessionOnNextHit) {
//			url += AddOptionalMPParameter(Fields.SESSION_CONTROL, "end");
//			endSessionOnNextHit = false;
//		}
//		// Add random z to avoid caching
//		string newUrl = url + "&z=" + UnityEngine.Random.Range(0, 500);
//		if (GoogleAnalyticsV4.belowThreshold(logLevel, GoogleAnalyticsV4.DebugMode.VERBOSE)) {
//			Debug.Log(newUrl);
//		}
//		GoogleAnalyticsV4.getInstance().StartCoroutine(this.HandleWWW(new WWW(newUrl)));
//	}

//	/*
//	  Make request using yield and coroutine to prevent lock up waiting on request to return.
//	*/
//	public IEnumerator HandleWWW(WWW request) {
//		while (!request.isDone) {
//			yield return request;
//			if (request.responseHeaders.ContainsKey("STATUS")) {
//				if (request.responseHeaders["STATUS"].Contains("200 OK")) {
//					if (GoogleAnalyticsV4.belowThreshold(logLevel, GoogleAnalyticsV4.DebugMode.INFO)) {
//						Debug.Log("Successfully sent Google Analytics hit.");
//					}
//				} else {
//					if (GoogleAnalyticsV4.belowThreshold(logLevel, GoogleAnalyticsV4.DebugMode.WARNING)) {
//						Debug.LogWarning("Google Analytics hit request rejected with " +
//							"status code " + request.responseHeaders["STATUS"]);
//					}
//				}
//			} else {
//				if (GoogleAnalyticsV4.belowThreshold(logLevel, GoogleAnalyticsV4.DebugMode.WARNING)) {
//					Debug.LogWarning("Google Analytics hit request failed with error "
//						+ request.error);
//				}
//			}
//		}
//	}




}
