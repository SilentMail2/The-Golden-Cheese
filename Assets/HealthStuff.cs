using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStuff : MonoBehaviour {
	PlayerControl playerControl;
	public int HPamount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			playerControl = other.gameObject.GetComponent<PlayerControl> ();
			if (HPamount>0 && playerControl.hp < 3) {
				playerControl.GiveHp (HPamount);
				Destroy (this.gameObject);
			}
		}
	}
}
