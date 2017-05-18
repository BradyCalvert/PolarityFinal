using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomEntranceDoorClose : MonoBehaviour {


    public GameObject TheClosedDoor;
    public GameObject OpenDoorThatsClosing;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TheClosedDoor.SetActive(true);
            OpenDoorThatsClosing.SetActive(false);
        }
    } 
}
