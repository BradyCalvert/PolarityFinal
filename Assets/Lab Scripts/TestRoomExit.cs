using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomExit : MonoBehaviour
{

    public GameObject ClosedDoorToOpen;
    public GameObject TheOpenDoor;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            ClosedDoorToOpen.SetActive(false);
            TheOpenDoor.SetActive(true);
        }
    }


}
