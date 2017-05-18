using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource backgroundSFX;
	public AudioSource playerSFX;

	public static AudioManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (this.gameObject);
		DontDestroyOnLoad (this);
	}

	public void PlayBackgroundSFX(AudioClip clipToPlay)
	{
		backgroundSFX.clip = clipToPlay;
		backgroundSFX.Play ();
	}

	public void PlayPlayerSFX(AudioClip clipToPlay)
	{
		playerSFX.clip = clipToPlay;
		playerSFX.Play ();
	}
}
