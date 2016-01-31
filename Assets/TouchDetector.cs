using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {

	public int rune;
	private Color objectColor = new Color(255f, 255f, 255f, 255f); 
	private bool colorIsChanged;
	private bool disableMouseUp = false; 
	private bool disableMouseDown = false; 
	// Use this for initialization

	void Start () {
		//objectColor = gameObject.GetComponent<SpriteRenderer> ().color;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color(255f, 255f, 255f, 255f);
	}
	
	// Update is called once per frame
	void Update () {
		if(colorIsChanged == true){
			StartCoroutine(ChangeState());	
		}


	}

	void OnMouseDown(){
		Debug.Log (gameObject.name);
		if (!disableMouseDown) {
			if (!colorIsChanged) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (.7f, .7f, .7f, 1f);
				gameObject.GetComponent<AudioSource> ().Play ();
				colorIsChanged = true;
				disableMouseDown = true; 
			}
		}
	}

	void OnMouseUp() {

		if (!disableMouseUp) {
			GameObject controllerObj = GameObject.FindGameObjectWithTag ("GameController");
			Sequence sequencer = controllerObj.GetComponent<Sequence> ();
			GameController gameController = controllerObj.GetComponent<GameController> ();
			BindingBar bar = controllerObj.GetComponent<BindingBar> ();

			if (!sequencer.CheckSequence (rune)) {
				bar.DamagePlayer ();
				gameController.ShakeCamera ();

				if (bar.IsPlayerDead ()) {
					//Debug.Log ("Player is dead");
				} else {
					StartCoroutine (waitBeforeNextSeq (gameController));


					//Debug.Log ("Incorrect rune");
					//Debug.Log ("Progress: " + bar.GetProgress ());
				}
			} else if (sequencer.IsSequenceComplete ()) {
				bar.DamageDemon ();

				if (bar.IsDemonBound ()) { 
					//Debug.Log ("Demon is bound");
				} else {
					StartCoroutine (waitBeforeNextSeq (gameController));

					//Debug.Log ("Sequence correct");
					//Debug.Log ("Progress: " + bar.GetProgress ());	
				}
			}
			//Debug.Log ("Disabling mouse");
			disableMouseUp = true;
		}
	}

	IEnumerator ChangeState ()
	{
		yield return new WaitForSeconds(.2f);
		colorIsChanged = false; 
		gameObject.GetComponent<SpriteRenderer> ().color = objectColor; 
		//Debug.Log ("Enabling mouse");
		disableMouseDown = false; 
		disableMouseUp = false; 
	}

	IEnumerator waitBeforeNextSeq (GameController gc )
	{
		yield return new WaitForSeconds (2);
		gc.NextSequence ();
		disableMouseDown = false; 
		disableMouseUp = false; 

	}
}
