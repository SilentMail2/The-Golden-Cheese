using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelControl : MonoBehaviour {
	[SerializeField] private int maxCheese;
	public int collectedCheese;
	[SerializeField] private Text cheeseAmountText;
	[SerializeField] public Text collectedCheeseText;
	// Use this for initialization
	void Start () {
		cheeseAmountText.text = maxCheese.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
