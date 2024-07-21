
# Ideas
Playtesting can be great for...
- Small numbers of players who you can observe in person
- Early stages of development, where you might make broad changes in response
- Rich, qualitative information: how does this individual feel? what's the look on their face? Who are they as a person / player that might help give context to a reaction?
- Observing social interactions between multiple players

Metric data, on the other hand, is better for...
- Delivering a build to a larger community and getting information back from everyone who plays
- The kind of fine-tuning design decisions you might make later in development
- Spotting patterns that show up once a bigger population is playing, things that might be hard to see from just a few playtests
- Measuring anything that's binary (did it happen? yes/no) or measurable as a number (how long, how much, how many times)--quantitative, not qualitative


How long do players play?
How many accomplish particular objectives? (Finishing a chapter, scoring a certain # of points...)
How popular are particular items, resources, or strategies? (Assuming you can define the strategies!)
How successful at winning or achieving are players who use those things?
Which choices do players make, for instance at a narrative or dialogue branch?
How long do players spend doing various activities or on certain screens?
How long does it take before players figure out how to interact at a certain point in the game?
Where in the space of a game do certain events (like a player dying, or quitting, or using an item) tend to happen?


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
