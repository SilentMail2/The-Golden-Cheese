using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {
	public float xCoordA;
	public float xCoordB;
	public PlayerControl pControl;
	enum ActivateType
	{
		Door, Bridge, Trapdoor, spikeTrap
	};
	[SerializeField] private ActivateType type;
	bool isActive;
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
	}
}
