using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour {
	public GameObject Player;
	public bool isActivated;
	// Use this for initialization
	public bool PickedUpable;
	public float lookRadius = 10f;
	public Transform target;
	void Update ()
	{
		float distance = Vector3.Distance (Player.transform.position, transform.position);
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
	// Update is called once per frame
	void FixedUpdate () {
		if (isActivated) {
			transform.position = Vector3.MoveTowards (this.transform.position, Player.transform.position, 1000f);
		}
		if (!isActivated) {
			transform.position = transform.position;
		}
	}
	
}
