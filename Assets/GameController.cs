using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject blueSquare; 
	public GameObject yellowSquare; 
	public GameObject whiteSquare;
	public GameObject greenSqaure; 
	public GameObject redSqauare; 
	public GameObject darkOverlay; 
	private GameObject currentGameObject; 

	private int[] tempArray; 
	// Use this for initialization
	void Start () {
		tempArray = new int[]{2, 3, 2, 3, 2}; 
		StartCoroutine (waitForNextRune());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator waitForNextRune ()
	{
		
		for (int i = 0; i < tempArray.Length; i++) {
			Instantiate (darkOverlay, new Vector2 (0, 0), Quaternion.identity);
			switch(tempArray[i]){
			case 0:
				Instantiate (blueSquare, new Vector2 (0, 0), Quaternion.identity);
				break;
			case 1:
				Instantiate (yellowSquare, new Vector2 (0, 0), Quaternion.identity);
				break;
			case 2:
				Instantiate (greenSqaure, new Vector2 (0, 0), Quaternion.identity);
				break;
			case 3:
				Instantiate (redSqauare, new Vector2 (0, 0), Quaternion.identity);
				break;
			case 4:
				Instantiate (whiteSquare, new Vector2 (0, 0), Quaternion.identity);
				break; 
			}
			yield return new WaitForSeconds(.5f);

			currentGameObject = GameObject.FindGameObjectWithTag ("bigRune");
			Destroy(GameObject.FindGameObjectWithTag("DarkOverlay"));
			Destroy (currentGameObject);

			yield return new WaitForSeconds(.5f);
			waitForNextRune ();

		}	

	}
}
