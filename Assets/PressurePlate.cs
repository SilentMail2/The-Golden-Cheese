using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
	public bool isActivated;
	public int numPressed;
	[SerializeField] private GameObject activateObject;
	Activatable activateControl;

	void Start ()
	{
		
			activateControl = activateObject.GetComponent<Activatable> ();

	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "FullofCheese" || other.gameObject.tag == "Player") {
			isActivated = true;
			numPressed++;
			if (numPressed == 1) {
				activateControl.DoaThing ();
			}
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "FullofCheese" || other.gameObject.tag == "Player") {
			isActivated = false;
			numPressed--;
			if (numPressed == 0) {
				activateControl.DoaThing ();
			}
		}
	}

}
