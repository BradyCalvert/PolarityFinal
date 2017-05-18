using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour {

	public GameObject noteCanvas;
	public Text noteText;
	public string messageOnNote;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			Debug.Log (messageOnNote);
			if(noteText != null && noteCanvas != null)
			{
				noteCanvas.SetActive (true);
				noteText.text = messageOnNote;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Debug.Log ("Note area exited.");
			if (noteText != null && noteCanvas != null) 
			{
				noteCanvas.SetActive (false);
				noteText.text = "";
			}
		}
	}
}
