using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerControl : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private KeyCode activate;
	[SerializeField] private string vertical;
	[SerializeField] private string horizontal;
	[SerializeField] private float grav;
	public LevelControl lc;
	public int hp;
	[SerializeField] private GameObject[] h;
	public GameObject lever;

	private Vector3 moveDir = Vector3.zero;
	[SerializeField] private CharacterController cc;
	public bool isHiding;
	public bool hasCheese;
	public bool pickUpEnabled;
	public GameObject CheeseStone;
	public GameObject DesmTrigger;
	Activatable activation;
	public CheeseStone cheesyStone;
	LeverControl leverControl;

	public GameObject WinScreen;
	public GameObject DeathScreen;



	//Barrel stuff
	public GameObject Barrel;
	public BarrelScript barrelStuff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Moving ();
		if (!hasCheese && pickUpEnabled) {
			PickUp (CheeseStone);
		}
		if (hasCheese) {
			DropOff(CheeseStone);
		}
		CheckHP ();
		if (Input.GetKeyUp (activate)) {
			Debug.Log ("Getoutofbarrel1");
			barrelStuff.isActivated = false;
			Debug.Log ("Getoutofbarrel2");
			isHiding = false;
			Debug.Log ("Getoutofbarrel3");
		}
	}
	public void CheckHP(){
		if (hp < 3) {
			h [2].SetActive (false);
		}
		if (hp >= 3) {
			h [2].SetActive (true);
		}
		if (hp < 2) {
			h [1].SetActive (false);
		}
		if (hp >= 2) {
			h [1].SetActive (true);
		}
		if (hp < 1) {
			h [0].SetActive (false);
		}
		if (hp >= 1) {
			h [0].SetActive (true);
		}
		if (hp <= 0) {
			DeathScreen.SetActive (true);
			Time.timeScale = 0;
		}

	}

	public void GiveHp (int amount)
	{
		hp += amount;
	}

	public void Moving(){
		moveDir = new Vector3 (Input.GetAxisRaw (horizontal), 0, -Input.GetAxisRaw (vertical));
		moveDir = transform.TransformDirection (moveDir);
		moveDir = moveDir * speed;
		//gravity
		moveDir.y = moveDir.y - (grav * Time.deltaTime);
		//moving
		cc.Move (moveDir * Time.deltaTime);
	}

	public void PickUp (GameObject newParent)
	{
		if (Input.GetKeyDown (activate) && cheesyStone.PickedUpable) {
			newParent.transform.parent = this.transform;
			hasCheese = true;

		}
		if (Input.GetKeyDown (activate) && barrelStuff.PickedUpable) {
			barrelStuff.isActivated = true;
			isHiding = true;		
		}

	}

	public void DropOff (GameObject newParent)
	{
		if (Input.GetKeyUp (activate)) {
			newParent.transform.parent = null;
			hasCheese = false;

		}
/*		if (Input.GetKeyUp (activate)) {

		}
*/
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "FullofCheese" && !hasCheese) {
			CheeseStone = other.gameObject;
			cheesyStone = CheeseStone.GetComponent<CheeseStone> ();
			pickUpEnabled = true;
		}
		if (other.gameObject.tag == "Barrel" && !isHiding) {
			Barrel = other.gameObject;
			barrelStuff = Barrel.GetComponent<BarrelScript> ();
			pickUpEnabled = true;
		}
		if (other.gameObject.tag == "Lever") {
			lever = other.gameObject;
			leverControl = lever.GetComponent<LeverControl> ();
			if (Input.GetKeyDown (activate)) {
				leverControl.PullLever ();
			}
		}
		if (other.gameObject.tag == "Trap") {
			GiveHp (-4);
		}
		if (other.gameObject.tag == "Wealth") {
			Destroy (other.gameObject);
			lc.collectedCheese++;
		}
		if (other.gameObject.tag == "Spear") {
			other.gameObject.SetActive (false);
			GiveHp (-1);
		}
		if (other.gameObject.tag == "Desm") {
			DesmTrigger = other.gameObject;
			activation = DesmTrigger.GetComponent<Activatable> ();
			if (!isHiding) {
				activation.DoaThing ();
			}
		}
		if (other.gameObject.tag == "BigCheese") {
			WinScreen.SetActive (true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		pickUpEnabled = false;	
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Lever") {
			
			if (Input.GetKeyDown (activate)) {
				leverControl.PullLever ();
			}
		}
	}

}
