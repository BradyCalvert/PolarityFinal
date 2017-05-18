using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class AutoMoveTowardsPlayer : MonoBehaviour {

    [Header("Movement")]
    public float speed = 1.0f;

    private Transform playerTransform;

    private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Move towards the player
        myRigidBody.MovePosition(Vector3.Lerp(transform.position, playerTransform.position, Time.fixedDeltaTime * speed));
        transform.LookAt(playerTransform);
    }
}
