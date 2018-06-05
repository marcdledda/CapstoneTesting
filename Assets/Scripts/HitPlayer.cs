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
			Debug.Log("Got Hit");
			// Destroy(other.gameObject);
			// gameStateText.text = "You lose!";
			// DodgeWallState.gameStart = false;			
		}
	}
}
