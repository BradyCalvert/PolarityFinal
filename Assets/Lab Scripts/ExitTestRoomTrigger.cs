using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTestRoomTrigger : MonoBehaviour {

    public GameObject DoorToOpen;
    public GameObject ClosedDoorGoAway;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Positive2")
        {
            DoorToOpen.SetActive(true);
            ClosedDoorGoAway.SetActive(false);

        }
            
    }

    // Update is called once per frame
    void Update () {
		
	}
}
