using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOn : MonoBehaviour {

    public Light flashlight;

    void Start()
    {
flashlight.enabled = false;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
       

    }
}

