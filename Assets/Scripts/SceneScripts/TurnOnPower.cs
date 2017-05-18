using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnPower : MonoBehaviour {

    public GameObject lights;
    public GameObject transitionScene;
    public Text powerON;

    public void Start()
    {
        lights.SetActive(false);
        transitionScene.SetActive(false);
        powerON.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Player")
        {
            powerON.enabled = true;
        }        		
	}

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lights.SetActive(true);
            transitionScene.SetActive(true);
            Destroy(powerON);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            powerON.enabled = false;
        }
    }

 

}
