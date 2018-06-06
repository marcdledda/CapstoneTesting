using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPress : MonoBehaviour {

	private bool primeIndexPoint;
	private bool secondIndexPoint;
	[SerializeField]
	private GameObject Panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		primeIndexPoint = OVRInput.Get(OVRInput.NearTouch.PrimaryIndexTrigger);
		secondIndexPoint = OVRInput.Get(OVRInput.NearTouch.SecondaryIndexTrigger);
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "LHand"){
			if (!primeIndexPoint){
				checkDifficulty();
			}
		}

		if(other.gameObject.tag == "RHand"){
			if (!secondIndexPoint){
				checkDifficulty();
			}
		}
	}

	private void checkDifficulty(){
		if (gameObject.tag == "Easy"){
			//Easy
			DodgeWallState.panelShow = false;
			DodgeWallState.dodgeAmount = 0;
			MoveWall.speed = 13.5f;
			Destroy(Panel);
		} else if (gameObject.tag == "Med"){
			//Med
			DodgeWallState.panelShow = false;
			DodgeWallState.dodgeAmount = 0;
			MoveWall.speed = 18f;
			Destroy(Panel);
		} else if (gameObject.tag == "Hard"){
			//Hard
			DodgeWallState.panelShow = false;
			DodgeWallState.dodgeAmount = 0;
			MoveWall.speed = 24f;
			Destroy(Panel);
		}

	}
}
