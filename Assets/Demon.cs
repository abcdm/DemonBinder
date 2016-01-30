using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour {
	public int health;
	public int takeDamageAmount;
	public int attack;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void DamageDemon () {
		health -= takeDamageAmount;

		if (health <= 0) {
			// todo bind demon
		}
	}

	int GetHealth() {
		return health;
	}

	int GetAttack() {
		return attack;
	}
}
