using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetRepel : MonoBehaviour {

	private bool inside;
	[SerializeField]
	private float force = 1.5f;
	private Transform player;
	private Transform cube;
	private Rigidbody cubeRB;

	// Use this for initialization
	void Start () {
		inside = false;
		player = GameObject.Find("PlayerCube").GetComponent<Transform>();
		cube = GetComponentInParent<Transform>();
		cubeRB = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			inside = true;
			cubeRB.useGravity = false;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			inside = false;
			cubeRB.useGravity = true;
		}
	}

	void FixedUpdate(){
		if (inside){
			Vector3 magnetField = player.position - cube.position;
			cubeRB.AddForce(-force*magnetField);
		}
	}

}
