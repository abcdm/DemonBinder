using UnityEngine;
using System.Collections;

public class TouchDetector : MonoBehaviour {

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

	IEnumerator ChangeState ()
	{
		yield return new WaitForSeconds(.5f);
		colorIsChanged = false; 
		gameObject.GetComponent<SpriteRenderer> ().color = objectColor; 
	}
}
