# How to Track Data
Option 1: Call using code
In any of your scripts, you can log a data event by calling Tinylytics.AnalyticsManager.LogCustomMetric. You need to supply the metric name, and the data, which must be formatted as a string (if it is a int or float etc, use the .ToString() method when passing the data).
In this manner, you can embed the analytics tracking directly into your gameplay scripts.

> [!CAUTION]
> The game can only send so much data at once. Do not log data in the Update() loop!


```
Tinylytics.AnalyticsManager.LogCustomMetric("MetricName", "Data to send (as a string)" );
```

Option 2: Customize the Analytics Manager
If you’re an advanced user, you can customize the analytics manager yourself. It’s located in Assets > Tinylytics_AlayticsTool > Backend, open AnalyticsManager.cs
You could write your own tracking commands here. “LogSessionPlaytime” is an example of how the manager could track playtime, and report it whenever called. In this way, you can extend Option 2 by consolidating your reporting code here.

Lastly to disable analytics:
Navigate to Assets/Tinylytics_AnalyticsTool/Resources/
Click on the Tinylytics_BackendManager prefab, and Uncheck “Analytics_Enabled”. If this is unchecked, no data will be sent.
