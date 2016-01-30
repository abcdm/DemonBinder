using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {
	public int rune;
	private Color objectColor = new Color(0f, 0f, 0f, 1f); 
	private bool colorIsChanged;
	// Use this for initialization

	void Start () {
		objectColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		if(colorIsChanged == true){
			StartCoroutine(ChangeState());

		}

	}

	void OnMouseDown(){
		if (!colorIsChanged) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f, 1f);
			colorIsChanged = true;
		}
	}

	void OnMouseUp() {
		GameObject controllerObj = GameObject.FindGameObjectWithTag ("GameController");
		Sequence sequencer = controllerObj.GetComponent<Sequence> ();
		GameController gameController = controllerObj.GetComponent<GameController> ();
		BindingBar bar = controllerObj.GetComponent<BindingBar> ();

		if (!sequencer.CheckSequence (rune)) {
			bar.DamagePlayer ();

			if (bar.IsPlayerDead ()) {
				Debug.Log ("Player is dead");
			} else {
				gameController.NextSequence ();

				Debug.Log ("Incorrect rune");
				Debug.Log ("Progress: " + bar.GetProgress ());
			}
		} else if (sequencer.IsSequenceComplete()) {
			bar.DamageDemon ();

			if (bar.IsDemonBound ()) { 
				Debug.Log ("Demon is bound");
			} else {
				gameController.NextSequence ();
				Debug.Log ("Sequence correct");
				Debug.Log ("Progress: " + bar.GetProgress ());	
			}
		}
	}

	IEnumerator ChangeState ()
	{
		yield return new WaitForSeconds(.5f);
		colorIsChanged = false; 
		gameObject.GetComponent<SpriteRenderer> ().color = objectColor; 
	}
}
