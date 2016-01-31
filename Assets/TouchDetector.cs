using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {

	public int rune;
	private Color objectColor = new Color(255f, 255f, 255f, 255f); 
	private bool colorIsChanged;
	private bool disableColliders = false;
	// Use this for initialization

	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color(255f, 255f, 255f, 255f);
	}
	
	// Update is called once per frame
	void Update () {
		if(colorIsChanged){
			colorIsChanged = false; 
			StartCoroutine(ChangeState());	
		}
	}

	void OnMouseDown(){
		if (!colorIsChanged) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (.7f, .7f, .7f, 1f);
			gameObject.GetComponent<AudioSource> ().Play ();

			gameObject.GetComponent<BoxCollider2D> ().enabled = false;

			GameObject controllerObj = GameObject.FindGameObjectWithTag ("GameController");
			Sequence sequencer = controllerObj.GetComponent<Sequence> ();
			GameController gameController = controllerObj.GetComponent<GameController> ();
			BindingBar bar = controllerObj.GetComponent<BindingBar> ();

			if (!sequencer.CheckSequence (rune)) {
				bar.DamagePlayer ();
				gameController.ShakeCamera ();

				if (bar.IsPlayerDead ()) {
					Debug.Log ("Player is dead");
				} else {
					disableColliders = true;
					gameController.SwitchRuneColliders (false);
					StartCoroutine (waitBeforeNextSeq (gameController));

					Debug.Log ("Incorrect rune");
					Debug.Log ("Progress: " + bar.GetProgress ());
				}
			} else if (sequencer.IsSequenceComplete ()) {
				bar.DamageDemon ();

				if (bar.IsDemonBound ()) { 
					Debug.Log ("Demon is bound");
				} else {
					disableColliders = true;
					gameController.SwitchRuneColliders (false);
					StartCoroutine (waitBeforeNextSeq (gameController));

					Debug.Log ("Sequence correct");
					Debug.Log ("Progress: " + bar.GetProgress ());	
				}
			}

			colorIsChanged = true;
		}
	}

	IEnumerator ChangeState ()
	{
		yield return new WaitForSeconds(.2f);
		gameObject.GetComponent<SpriteRenderer> ().color = objectColor;

		if (!disableColliders) {
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}

		disableColliders = false;
	}

	IEnumerator waitBeforeNextSeq (GameController gc )
	{
		yield return new WaitForSeconds (2);
		gc.NextSequence ();

	}
}
