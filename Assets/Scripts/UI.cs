using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void MainToLab()
    {
        SceneManager.LoadScene("Polarity-Laboritiry training");
    }

    void CreditsToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
