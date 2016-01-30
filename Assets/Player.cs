using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void DamagePlayer(int damageAmount) {
		health -= damageAmount;

		if (health <= 0) {
			// todo player has been defeated
		}
	}

	int GetHealth() {
		return health;
	}
}
