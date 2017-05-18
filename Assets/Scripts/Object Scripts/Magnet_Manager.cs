using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Manager : MonoBehaviour {
    [HideInInspector]
    public static Magnet_Manager instance;
    [HideInInspector]
    public List<GameObject> thingsToMove = new List<GameObject>();
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public Color targetColour;
    [HideInInspector]
    public bool shouldMove = false;
    [HideInInspector]
    public bool timerStarted = false;
    public float shootForce = 1f;

    public GameObject player;

   public AudioClip swishSound;
    private void Awake()
    {
        player = GameObject.Find("Player");
        instance = this;
    }
    public void Subscribe(GameObject toSubscribe)
    {
        if (thingsToMove.Contains(toSubscribe))
            return;

        Debug.Log("Subscribing " + toSubscribe.name);
        thingsToMove.Add(toSubscribe);       
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void PleaseCommentDownBelow(GameObject toUnsubscribe)
    {
        Debug.Log("Unsubscribing");

        if (thingsToMove.Contains(toUnsubscribe))
        {
            thingsToMove.Remove(toUnsubscribe);
        }
    }
    public void MoveObjects()
    {
        if (shouldMove == true)
            StopCoroutine("CoroutineObjects");

        StartCoroutine("CoroutineObjects");

        if (timerStarted == false)
        {
            timerStarted = true;
            Invoke("StopMoving", 2f);
        }
    } 
    public IEnumerator CoroutineObjects()
    {
        shouldMove = true;
        while (shouldMove)
        {
            Audio_Manager.instance.Other(swishSound);
            foreach (GameObject obj in thingsToMove)
            {
                if (obj != null)
                {
                    Rigidbody body;
                    if (obj.GetComponent<Rigidbody>() == null)
                        body = obj.AddComponent<Rigidbody>();
                    else
                        body = obj.GetComponent<Rigidbody>();

                    Vector3 moveDir = target.transform.position - obj.transform.position;
                    body.AddForce(moveDir.normalized * shootForce, ForceMode.Impulse);
                }
            }
            if (thingsToMove.Count <= 0 )
            {
                shouldMove = false;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    void StopMoving()
    {
        shouldMove = false;
        timerStarted = false;
        target.GetComponent<Renderer>().material.color = targetColour;
        target.tag = "Untagged";
        target = null;    
    }
}
