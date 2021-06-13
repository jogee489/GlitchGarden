using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {


	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.ChangeVolume(volume);
		} else {
			Debug.LogWarning("Unable to find MusicManager. Can not set volume.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
