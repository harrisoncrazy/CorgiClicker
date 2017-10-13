using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorgiHandler : MonoBehaviour {

	public static CorgiHandler Instance;

	public GameObject poopPrefab;
	public Transform poopHole;

	public float hungerMeter = 20.0f;
	public float sleepMeter = 20.0f;

	private float hungerTimer = 1.0f;
	private float foodSaturationTotal = 5;
	private int foodSaturationLast = 5;
	private float poopTimer = 30.0f;

	//random movement
	private Vector3 posTo;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	// Use this for initialization
	void Start () {
		Instance = this;

		findRandomPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		poopClock ();
		hungerMath ();
		goTowardsPosition ();
	}

	public void feedSnack() {
		hungerMeter -= 20.0f;
		foodSaturationTotal -= 2;
		poopTimer -= 10.0f;
	}

	public void feedMeal() {
		hungerMeter -= 50.0f;
		foodSaturationTotal -= 5;
		poopTimer -= 20.0f;
	}

	void findRandomPosition() {
		float xPos = Random.Range (xMin, xMax);//random x position within range
		float yPos = Random.Range (yMin, yMax);//random y position within range

		posTo = new Vector3 (xPos, yPos);//setting vector
		flipImage();
	}

	void goTowardsPosition() {
		transform.position = Vector2.MoveTowards (transform.position, posTo, 1.0f * Time.deltaTime);//moving towards point

		if (transform.position == posTo) { //finding new point once reached
			findRandomPosition ();
		}
	}

	void flipImage() {
		if (posTo.x < transform.position.x) {
			Vector3 newScale = this.gameObject.transform.localScale;
			newScale.x = -1;
			transform.localScale = newScale;
		} else if (posTo.x > transform.position.x) {
			Vector3 newScale = this.gameObject.transform.localScale;
			newScale.x = 1;
			transform.localScale = newScale;
		}
	}

	void hungerMath() {
		hungerMeter = Mathf.Clamp (hungerMeter, 0.0f, 100.00f);
		foodSaturationTotal = Mathf.Clamp (foodSaturationTotal, 0.0f, 10.0f);
		hungerClock ();
	}

	void hungerClock() {
		hungerTimer -= Time.deltaTime;
		if (hungerTimer < 0) {
			hungerMeter += 1.0f * foodSaturationTotal;
			Debug.Log (hungerMeter);
			foodSaturationLast--;
			if (foodSaturationLast == 0) {
				foodSaturationTotal++;
				foodSaturationLast = 5;
			}
			hungerTimer = 1.0f;
		}
	}

	void poopClock() {
		poopTimer -= Time.deltaTime;
		if (poopTimer < 0) {
			Debug.Log ("Pooped!");
			GameObject poopClone = (GameObject)Instantiate (poopPrefab, poopHole.position, transform.rotation);
			poopTimer = 30.0f;
		}
	}
}
