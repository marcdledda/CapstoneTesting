using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMovement : MonoBehaviour {

	public static float speed;
	[SerializeField]
	private Rigidbody blockPrefab;
	public BalanceState stateScript;
	private bool collisionOn = false;

	// Use this for initialization
	void Start () {
		GameObject stateObject = GameObject.Find("BalanceState");
		BalanceState stateScript = (BalanceState) stateObject.GetComponent(typeof(BalanceState));
		speed = 1f;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Platform" || other.gameObject.tag == "buildBlock") {
			collisionOn = true;
			stateScript.SpawnBlock();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!collisionOn){
			blockPrefab.AddForce(speed * -transform.up);
		} else if (collisionOn) {
			blockPrefab.useGravity = true;
		}
		
	}
}
