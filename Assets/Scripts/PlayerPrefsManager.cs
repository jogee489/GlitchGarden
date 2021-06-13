using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	// Set the master volume preference.
	public static void SetMasterVolume(float volume) {
		if (volume >= 0f && volume <= 1f) { 
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}
	
	// Set the difficulty preference.
	public static void SetDifficulty(float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty not within range.");
		}
	}
	
	// Set the level unlocked.
	public static void SetLevelUnlocked(int level) {
		if (level <= Application.levelCount -1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Level is not in the build order");
		}
	}
	
	// Get the master volume preference.
	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	// Get the difficulty preference.
	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
	// Get the level unlocked.
	public static bool IsLevelUnlocked(int level) {
		if (level <= Application.levelCount -1) {
			return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
		} else {
			Debug.LogError("Level is not in the build order");
			return false;
		}
	}
}
