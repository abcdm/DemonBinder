﻿using UnityEngine;
using System.Collections;

public class BindingBar : MonoBehaviour {
	public int goal;
	int progress;
	public GameObject healthBar;
	public float leftX = -2.05f;
	public float rightX = 1.8f;
	float stepX;

	// Use this for initialization
	void Start () {
		progress = (int) Mathf.Floor (goal / 4);
		stepX = (rightX - leftX) / goal;
		MoveBar (progress);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveBar(int direction) {
		Vector3 move = new Vector3 (direction * stepX, 0f, 0f);
		float movedX = (healthBar.transform.position + move).x;

		if (movedX > rightX) {
			healthBar.transform.position = new Vector3(rightX, healthBar.transform.position.y, 0f);
		} else if (movedX < leftX) {
			healthBar.transform.position = new Vector3(leftX, healthBar.transform.position.y, 0f);
		} else {
			healthBar.transform.Translate (move);
		}
	}

	public void DamageDemon() {
		progress++;
		MoveBar (1);
	}

	public void DamagePlayer() {
		progress--;
		MoveBar (-1);
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
