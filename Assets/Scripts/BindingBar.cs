using UnityEngine;
using System.Collections;

public class BindingBar : MonoBehaviour {
	public int goal;
	int progress;

	// Use this for initialization
	void Start () {
		progress = (int) Mathf.Floor (goal / 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DamageDemon() {
		progress++;
	}

	public void DamagePlayer() {
		progress -= 1;//damage; // todo parameter
	}

	public int GetGoal() {
		return goal;
	}

	public int GetProgress() {
		return progress;
	}

	public bool IsPlayerDead() {
		return progress <= 0;
	}

	public bool IsDemonBound() {
		return progress >= goal;
	}
}
