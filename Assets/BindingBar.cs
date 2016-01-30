using UnityEngine;
using System.Collections;

public class BindingBar : MonoBehaviour {
	public int goal;
	int progress;

	// Use this for initialization
	void Start () {
		progress = (int) Mathf.Floor (goal / 4);
		Debug.Log ("Goal: " + goal + " Progress: " + progress);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DamageDemon() {
		progress++;

		if (progress >= goal) {
			Debug.Log ("demon has been bound");
		}
	}

	public void DamagePlayer() {
		progress -= 1;//damage; // todo temp

		if (progress <= 0) {
			Debug.Log ("player is dead");
		}
	}

	public int GetGoal() {
		return goal;
	}

	public int GetProgress() {
		return progress;
	}

	public bool IsPlayerDead() {
		return progress == 0;
	}

	public bool IsDemonBound() {
		return progress == goal;
	}
}
