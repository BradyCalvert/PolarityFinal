using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour {
  public AudioSource backgroundMaster;
  public AudioSource playerSFX;
  public AudioSource enemySFX;
  public AudioSource environmentSFX;
  public AudioSource other;
  public static Audio_Manager instance = null;
  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
      Destroy(gameObject);
    DontDestroyOnLoad(gameObject);
  }
  public void PlayBackground(AudioClip soundToPlay)
  {
    backgroundMaster.clip = soundToPlay;
    backgroundMaster.Play();
  }
  public void PlayerSFX(AudioClip soundToPlay)
  {
    playerSFX.clip = soundToPlay;
    playerSFX.Play();
  }
  public void EnemySFX(AudioClip soundToPlay)
  {
    enemySFX.clip = soundToPlay;
    enemySFX.Play();
  }

  public void EnvironmentSFX(AudioClip soundToPlay)
  {
    environmentSFX.clip = soundToPlay;
    environmentSFX.Play();
  }

  public void Other(AudioClip soundToPlay)
  {
    other.clip = soundToPlay;
    other.Play();
  }
}
