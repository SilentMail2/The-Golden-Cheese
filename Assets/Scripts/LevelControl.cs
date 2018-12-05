using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelControl : MonoBehaviour {
	[SerializeField] private int maxCheese;
	public int collectedCheese;
	[SerializeField] private Text cheeseAmountText;
	[SerializeField] public Text collectedCheeseText;
	public GameObject CheeseCasing;
	int scene;
	// Use this for initialization
	void Start () {
		cheeseAmountText.text = maxCheese.ToString();
		scene = SceneManager.GetActiveScene ().buildIndex;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		collectedCheeseText.text = collectedCheese.ToString ();
		if (collectedCheese == maxCheese) {
			CheeseCasing.SetActive (false);
		}
	}
	public void RestartLevel()
	{
		
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
}
