using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public static UIHandler Instance;

	public Image healthBar;
	public Text poopNum;

	public int numPoopsCollected = 0;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		drawHungerBar ();
		setPoopText ();
	}

	void drawHungerBar() {
		float barPercentage = CorgiHandler.Instance.hungerMeter / 100.0f;//getting the hunger meter in a factor between 0 and 1

		healthBar.fillAmount = barPercentage;
	}

	void setPoopText() {
		poopNum.text = "Number of poops collected: " + numPoopsCollected;
	}
}
