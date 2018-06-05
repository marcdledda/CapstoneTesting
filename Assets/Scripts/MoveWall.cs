using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {

	[SerializeField]
	float speed = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * Time.deltaTime * speed);
		if (transform.position.z < -8f ){
			Destroy(gameObject);
			DodgeWallState.dodgeAmount++;
			DodgeWallState.cubeExist = false;
		}
	}
}
