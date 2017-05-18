using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

	public Light lightBulb;
	public float intensityMin = 1.5f;
	public float intensityMax = 2.1f;
	public float lightRangeMin = 8;
	public float lightRangeMax = 15;
	public float repeatRateMin = .01f;
	public float repeatRateMax = .1f;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("LightRange", 0f, Random.Range(repeatRateMin, repeatRateMax));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void LightRange()
	{
		lightBulb.intensity = Random.Range (intensityMin, intensityMax);
		lightBulb.range = Random.Range (lightRangeMin, lightRangeMax);
	}
}
