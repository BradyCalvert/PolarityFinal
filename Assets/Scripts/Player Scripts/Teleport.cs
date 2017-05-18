using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject spotToTeleportTo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			other.transform.position = spotToTeleportTo.transform.position;
			other.transform.rotation = spotToTeleportTo.transform.rotation;
		}
	}
}
