using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

    public AudioClip startClip; // these are the audio clips for the scenes.
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Start () {
		if (instance != null && instance != this) { // && instance != this is there to make sure we don't destroy the last instance of the music manager. So once we've got this as the instance, we don't want to destroy it. This is done this way because the music isn't going to spawn again the same track, they want it in this game to change to a new track when moving to a new scene. I don't really know what any of this code translates to in english.
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
		}
		
	}
    
    void OnSceneLoaded(int level)
    {
        Debug.Log("Music Player Level Loaded"+level);
        music.Stop();

        if (level == 0)
        {
            music.clip = startClip;
        }
        if (level == 1)
        {
            music.clip = gameClip;
        }
        if (level == 2)
        {
            music.clip = endClip;
        }
        music.loop = true;
        music.Play();
    }
}
