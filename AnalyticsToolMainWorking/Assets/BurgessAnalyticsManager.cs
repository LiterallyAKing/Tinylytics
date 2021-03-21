
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tinylytics;

public class BurgessAnalyticsManager : MonoBehaviour {

	public static BurgessAnalyticsManager me = null;


	public bool useAnalytics;


	string LevelIndex {
		//get { return Persist.s.CurrentLevelIndex.ToString(); }
		get { return "1"; }
	}

	float sessionStartTime = 0;
	float sessionTime = 0;
	public float SessionTime {
		get { return sessionTime; }
	}

	float currentLevelStartTime = 0;
	float levelTime = 0;
	public float LevelTime {
		get { return levelTime; }
	}

	int levelMoveCount = 0;
	public int LevelMoveCount {
		get { return levelMoveCount; }
	}

	int levelUndoCount = 0;
	public int LevelUndoCount {
		get { return levelUndoCount; }
	}

	int levelFailStateCount = 0;
	public int LevelFailStateCount {
		get { return levelFailStateCount; }
	}

	int levelSolutionMoveCount = 0;
	public int LevelSolutionMoveCount {
		get { return levelSolutionMoveCount; }
	}

	int levelHighestNumberOfConsecutiveMovesWithoutUndo = 0;
	public int LevelHighestNumberOfConsecutiveMovesWithoutUndo {
		get { return levelHighestNumberOfConsecutiveMovesWithoutUndo; }
	}

	int movesSinceLastUndo = 0;


	void Awake() {
		if (me == null) {
			DontDestroyOnLoad(this);
			me = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	void Start() {
		sessionStartTime = Time.time;
	}

	void OnApplicationPause() {
		// NOTE need to handle pause as session end for iOS, probably requires dealing with resume as well
	}

	void OnApplicationQuit() {
		LogSessionEnd();
	}

	public void LogLevelBegin() {
		currentLevelStartTime = Time.time;
	}

	public void LogLevelEnd(int moveCount) {
		levelTime = Time.time - currentLevelStartTime;
		levelSolutionMoveCount = moveCount;

		if (useAnalytics) PostLevelEndData();
		ResetLevelValues();
	}

	public void LogSessionEnd() {
		sessionTime = Time.time - sessionStartTime;
		if (useAnalytics) PostSessionEndData();
	}

	public void LogMove() {
		levelMoveCount++;
		movesSinceLastUndo++;

		if (movesSinceLastUndo > levelHighestNumberOfConsecutiveMovesWithoutUndo) {
			levelHighestNumberOfConsecutiveMovesWithoutUndo = movesSinceLastUndo;
		}
	}

	public void LogUndo() {
		levelUndoCount++;
		movesSinceLastUndo = 0;
	}

	public void LogFailState() {
		levelFailStateCount++;
	}

	void PostSessionEndData() {
		BackendManager.SendData("ended on level " + LevelIndex + ". session time", sessionTime.ToString());
	}

	void PostLevelEndData() {
		BackendManager.SendData("level " + LevelIndex + " time", levelTime.ToString());
		BackendManager.SendData("level " + LevelIndex + " move count", levelMoveCount.ToString());
		BackendManager.SendData("level " + LevelIndex + " undo count", levelUndoCount.ToString());
		BackendManager.SendData("level " + LevelIndex + " fail state count", levelFailStateCount.ToString());
		BackendManager.SendData("level " + LevelIndex + " solution move count", levelSolutionMoveCount.ToString());
		BackendManager.SendData("level " + LevelIndex + " highest number of consecutive moves without undo", levelHighestNumberOfConsecutiveMovesWithoutUndo.ToString());
	}

	void ResetLevelValues() {
		levelUndoCount = 0;
		levelMoveCount = 0;
		levelFailStateCount = 0;
		levelSolutionMoveCount = 0;
		levelHighestNumberOfConsecutiveMovesWithoutUndo = 0;
		movesSinceLastUndo = 0;
	}
}