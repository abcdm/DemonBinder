using UnityEngine;
using System.Collections;

public class Sequence : MonoBehaviour {

	protected int position;
	protected int[] sequence;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			
		}
	
	}

	public void ResetPosition() {
		position = 0;
	}

	public int[] GenerateSequence(int length) {
		sequence = new int[length];
		int recent = -1;
		int number;
		bool doubled = false;
		bool generateNumber;

		for (int i = 0; i < length; i++) {
			do {
				generateNumber = false;
				number = Random.Range (0, 4);

				if (number == recent) {
					if (doubled) {
						generateNumber = true;
					} else {
						doubled = true;
					}
				} else {
					recent = number;
					doubled = false;
				}
			} while (generateNumber) ;

			sequence [i] = number;
		}

		return sequence;
	}

	public bool CheckSequence(int rune) {
		bool correct = (sequence [position] == rune);
		position++;
		return correct;
	}

	public bool IsSequenceComplete() {
		return position >= sequence.Length;
	}
}
