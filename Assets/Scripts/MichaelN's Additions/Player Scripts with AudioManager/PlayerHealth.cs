using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int playerHealth;
	public int healthToRemove = 25;
	int maxHealth = 100;

	public AudioClip playerDamage;
	public AudioClip playerDeath;

	public static PlayerHealth instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (this.gameObject);
		DontDestroyOnLoad (this);

		Debug.Log ("Pressing Q removes a pre-determined amount of health set in the inspector.");

		playerHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Q))
		{
			playerHealth -= healthToRemove;
			Debug.Log (playerHealth);
		}

		if (playerHealth <= 0) 
		{
			if (playerDeath != null)
				AudioManager.instance.PlayPlayerSFX (playerDeath);
			playerHealth = 100;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	public void TakeDamage(int damage)
	{
		if (playerDamage != null)
			AudioManager.instance.PlayPlayerSFX (playerDamage);

		playerHealth -= damage;
	}
}
