using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetector : MonoBehaviour {

	public Text itemText;
	public GameObject playerGun;
	public GameObject switchToPull;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) 
		{
			if (hit.transform.CompareTag ("Item"))
				itemText.text = "Press 'E' to pick up";
			else 
			{
				itemText.text = "";
			}

			if (hit.transform.CompareTag ("Item") && Input.GetKeyDown (KeyCode.E)) 
			{
				if (hit.transform.gameObject.layer == playerGun.layer)
					playerGun.SetActive (true);
				if (switchToPull != null) 
				{
					if (hit.transform.gameObject.layer == switchToPull.layer)
						GameObject.Find ("LightCommand").GetComponent<LightCommand> ().isSwitchFlippedOn = true;
				}
				if(hit.transform.gameObject.layer != switchToPull.layer)
					hit.transform.gameObject.SetActive (false);
			}
		} 
	}
}
