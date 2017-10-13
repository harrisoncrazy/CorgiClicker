using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour {

	public void SnackCall() {
		CorgiHandler.Instance.feedSnack ();
	}

	public void MealCall() {
		CorgiHandler.Instance.feedMeal ();
	}

	public void Exit() {
		Application.Quit ();
	}
}
