using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseStone : MonoBehaviour {
	public bool PickedUpable;
	public float lookRadius = 10f;
	public Transform target;
	void Update ()
	{
		float distance = Vector3.Distance (target.position, transform.position);
		if (distance <= lookRadius) {
			PickedUpable = true;
		} else {
			PickedUpable = false;
		}
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, lookRadius);
	}
}
