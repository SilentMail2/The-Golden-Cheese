using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour {
	[SerializeField] private GameObject lever;
	[SerializeField] private GameObject Object;
	public bool isPulled;
	Activatable activateControl;

	void Start ()
	{

		activateControl = Object.GetComponent<Activatable> ();

	}
	void Update ()
	{
		if (!isPulled) {
			lever.transform.localPosition = new Vector3 (0.25f, 0.32f, 0);
		}
		if (isPulled) {
			lever.transform.localPosition = new Vector3 (-0.08f, 0.32f, 0);
		}
	}
	public void PullLever ()
	{
		if (!isPulled) {
			isPulled = true;
		}
		if (isPulled) {
			isPulled = false;
		}
		activateControl.DoaThing ();
	}

}
