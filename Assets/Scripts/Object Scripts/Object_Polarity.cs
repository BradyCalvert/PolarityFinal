using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Polarity : MonoBehaviour
{
    string myPolarity;
    public int damage;
    Color thisCol;

    void Start()
    {
        thisCol = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Positive"))   //blue bullet
        {
            Magnet_Manager.instance.Subscribe(this.gameObject);
            gameObject.tag = "Positive2";
            myPolarity = "blue";
            GetComponent<Renderer>().material.color = Color.blue;
        }

        if (other.CompareTag("Negative")) //red bullet
        {
            if (Magnet_Manager.instance.target != null)

            Magnet_Manager.instance.target = this.gameObject;
            Magnet_Manager.instance.SetTarget(this.gameObject);
            Magnet_Manager.instance.targetColour = this.gameObject.GetComponent<Renderer>().material.color;

            Magnet_Manager.instance.MoveObjects();
            gameObject.tag = "Negative2";
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision entered");
        Debug.Log("My polarity " + myPolarity);
        if (myPolarity == "blue")
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.CompareTag("Negative2") == true) //blue square
            {
                Debug.Log("Did something");
                gameObject.tag = "Untagged";
                Magnet_Manager.instance.PleaseCommentDownBelow(other.gameObject);
                gameObject.GetComponent<Renderer>().material.color = thisCol;
                //DEAL DAMAGE TO ENEMY
            }
        }
    }

}
