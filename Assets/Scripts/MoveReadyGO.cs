using UnityEngine;
using System.Collections;

public class MoveReadyGO : MonoBehaviour {

	public Canvas canvas; 
	private float yStop = -2.75f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= yStop){
			transform.Translate (Vector2.up * .06f);
		}
		else{
			StartCoroutine (KeepMoving ());
		}


		//Y-position = -2.75 STOP
		//Y-positoin = 3.45 STOP again


	}
	IEnumerator KeepMoving ()
	{
		yield return new WaitForSeconds(2);
		if (yStop == 3.05f) {
			StartCoroutine (KillIt ());
		} else {
			yStop = 3.05f; 
		}
	}
	IEnumerator KillIt ()
	{
		yield return new WaitForSeconds(2);
		Camera.main.GetComponent<AudioSource> ().Play ();
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().NextSequence ();
		Destroy (gameObject);
	}


}
