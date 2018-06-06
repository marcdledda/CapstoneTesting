using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodgeWallState : MonoBehaviour {

	private Vector3 getSize;
	[SerializeField]
	private Transform platform;
	[SerializeField]
	private GameObject cubePrefab;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private Transform difficultPanel;
	public static int dodgeAmount;
	private bool changePlat = false;
	public static bool cubeExist;
	public static bool gameStart;

	// Use this for initialization
	void Start () {
		getSize = OVRManager.boundary.GetDimensions(OVRBoundary.BoundaryType.PlayArea);
		cubeExist = false;
		dodgeAmount = 0;
		gameStart = false;
		if (getSize.x < 2.1f){
			platform.localScale = new Vector3(getSize.x/10f, 1f, 1.5f);
			changePlat = true;
		}
		float panelZ = -6.5f - 0.15f + (getSize.z/2f);
		difficultPanel.position = new Vector3(0f, 1.7f, panelZ);
	}
	
	// Update is called once per frame
	void Update () {
		bool pressA = OVRInput.GetUp(OVRInput.Button.One);
		if (pressA){
			dodgeAmount = 0;
			gameStart = true;
			gameStateText.text = "Dodge the walls!";
		}

		if (dodgeAmount == 20) {
			gameStart = false;
			gameStateText.text = "You dodged all the walls, Press A to try again!";
			cubeExist = false;
		}

		if (!cubeExist && gameStart){
			if (changePlat){
				float range = (getSize.x/10f) * 5f - 0.25f;
				float positionX = Random.Range(-range, range);

				Vector3 objectPosition = new Vector3(positionX, 1.5f, 7f);

				Instantiate(cubePrefab, objectPosition, Quaternion.identity);

				cubeExist = true;
			} else {
				float positionX = Random.Range(-0.75f, 0.75f);

				Vector3 objectPosition = new Vector3(positionX, 1.5f, 7f);

				Instantiate(cubePrefab, objectPosition, Quaternion.identity);

				cubeExist = true;
			}
		}
	}
}
