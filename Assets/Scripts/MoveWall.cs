using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {

	public static float speed;

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
