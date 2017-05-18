using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCommand : MonoBehaviour {

	public GameObject lightParent;
	public int enemyCount;
	public bool isSwitchFlippedOn = false;
	bool areLightsOn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSwitchFlippedOn == true || enemyCount <= 0)
			lightParent.SetActive (false);
		else
			lightParent.SetActive (true);
	}
}
