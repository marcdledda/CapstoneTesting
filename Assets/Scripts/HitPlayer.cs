using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour {

	[SerializeField]
	private Text gameStateText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Wall"){
			Destroy(other.gameObject);
			gameStateText.text = "You lose, Press A to Start Again!";
			DodgeWallState.countdown = 5f;
			DodgeWallState.gameStart = false;
			DodgeWallState.cubeExist = false;			
		}
	}
}
