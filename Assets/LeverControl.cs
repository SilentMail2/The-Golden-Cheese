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
			lever.transform.localPosition = new Vector3 (-6.618f, 0.773f, -4.805f);
		}
		else if (isPulled) {
			lever.transform.localPosition = new Vector3 (-6.618f, -0.16f, -4.805f);
		}
	}
	public void PullLever ()
	{
		if (!isPulled) {
			isPulled = true;
		}
		else if (isPulled) {
			isPulled = false;
		}
		activateControl.DoaThing ();
	}

}
