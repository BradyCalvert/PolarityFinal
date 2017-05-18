using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text healthText;
	public Image healthBar;
	public Text ammoText;
	public Image ammoBar;
	public Text negativeAmmoText;
	public Image negativeAmmoBar;
	public CharacterShoot characterShoot;

	void Start()
	{
		healthBar.type = Image.Type.Filled;
		healthBar.fillMethod = Image.FillMethod.Horizontal;

		ammoBar.type = Image.Type.Filled;
		ammoBar.fillMethod = Image.FillMethod.Horizontal;
	}

	// Update is called once per frame
	void Update () 
	{
		if (healthText != null && healthBar != null) 
		{
			healthText.text = PlayerHealth.instance.playerHealth + "%";
			healthBar.fillAmount = (PlayerHealth.instance.playerHealth / 100f);
		}

		if (ammoText != null && ammoBar != null) 
		{
			ammoText.text = Convert.ToString (characterShoot.posBullets);
			ammoBar.fillAmount = (characterShoot.posBullets / 10f);
		}


		if (negativeAmmoText != null && negativeAmmoBar != null) 
		{
			if ((characterShoot.posBullets < 10 && GameObject.FindGameObjectWithTag ("Positive2") == true) || GameObject.FindGameObjectWithTag ("Positive2") == true) 
			{
				negativeAmmoText.text = "1";
				negativeAmmoBar.gameObject.SetActive (true);
			} 

			else 
			{
				negativeAmmoText.text = "0";
				negativeAmmoBar.gameObject.SetActive (false);
			}
		}
	}
}
