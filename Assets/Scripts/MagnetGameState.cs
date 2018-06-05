using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagnetGameState : MonoBehaviour {

	private bool loading = false;

	// Use this for initialization
	void Start () {
		// SceneManager.LoadScene("NotVRLoad", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space) && !loading){
			loading = true;
			// SceneManager.GetSceneByName("NotVRLoad");
			SceneManager.LoadScene("NotVRLoad");
		}
	}
}
