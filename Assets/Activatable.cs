using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {
	public float xCoordA;
	public float xCoordB;
	public PlayerControl pControl;
	//desm stuff
	public GameObject player;
	public GameObject spear;
	public bool thrown;
	public float step;
	public Activatable spearStuff;

	enum ActivateType
	{
		Door, Bridge, Trapdoor, spikeTrap, Desm, Spear
	};
	[SerializeField] private ActivateType type;
	bool isActive;
	void Start ()
	{
		if (type == ActivateType.Desm) {
			spearStuff = spear.GetComponent<Activatable> ();
		}
	}
	void Update ()
	{
		if (type == ActivateType.Spear && thrown) {
			DoaThing ();
		}
	}

	public void DoaThing ()
	{
		if (type == ActivateType.Door) {
			//opendoor
			Debug.Log ("DoorActivated");
			if (!isActive) {
				this.gameObject.transform.localPosition = new Vector3 (0, -1, 0);
				isActive = true;
			}
			else if (isActive)
			{
				this.gameObject.transform.localPosition = new Vector3 (0, 0, 0);
				isActive = false;
			
			}
		}
		if (type == ActivateType.Bridge) {
			Debug.Log ("Bridge");
			if (!isActive) {
				this.gameObject.transform.localPosition = new Vector3 (0.8f, 0, 0);
				isActive = true;
			}
			else if (isActive)
			{
				this.gameObject.transform.localPosition = new Vector3 (0, 0, 0);
				isActive = false;

			}
		}
		if (type == ActivateType.Trapdoor) {
			//trapdoor
		}
		if (type == ActivateType.spikeTrap) {
			pControl.GiveHp (-4);
		}

		if (type == ActivateType.Desm) {
			spearStuff.thrown = true;
		}
		if (type == ActivateType.Spear) 
		{
			transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position, step*Time.deltaTime);
		}
	}
}
