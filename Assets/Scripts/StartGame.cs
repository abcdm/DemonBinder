﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseUp() {
		//StartCoroutine (StartTheGame ());
		//GetComponent<AudioSource> ().Stop ();
		Application.LoadLevel ("GameScene");
	}

	IEnumerator StartTheGame ()
	{
		yield return new WaitForSeconds (2); 
		Application.LoadLevel ("GameScene");
	}//
}
