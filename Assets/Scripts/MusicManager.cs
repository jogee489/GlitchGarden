using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicArray;
	private AudioSource audioSource;
	
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	
	void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip levelMusic = levelMusicArray[level];
		// Load music if music is provided.
		if (levelMusic) {
			audioSource.clip = levelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume(float volume) {
		audioSource.volume = volume;
	}
}
