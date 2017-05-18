using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtyh : MonoBehaviour
{

    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Game object name : " + gameObject.name + " Collided with " + other.gameObject.tag);
        //if (!other.gameObject.CompareTag("Positive2"))
            //return;

        Object_Polarity polarityScript;
        polarityScript = other.gameObject.GetComponent<Object_Polarity>();

        if (polarityScript == null)
            return;

        Debug.Log("Game Object Name is : " + gameObject.name + " did damage");
        health -= polarityScript.damage;

        if (health <= 0)
        {
            Magnet_Manager.instance.PleaseCommentDownBelow(this.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
