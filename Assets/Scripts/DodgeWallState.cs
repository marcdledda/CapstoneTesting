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
	[SerializeField]
	private GameObject panelPrefab;
	public static int dodgeAmount;
	private bool changePlat = false;
	public static bool cubeExist;
	public static bool gameStart;
	public static float countdown;
	public static bool panelShow;

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
		panelShow = true;
		countdown = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (panelShow){
			gameStateText.text = "";
			countdown = 5f;
			dodgeAmount = 0;
		}else if (!panelShow) {
			startTime();
		}

		bool pressA = OVRInput.GetUp(OVRInput.Button.One);
		if (pressA && !gameStart && !cubeExist){
			startTime();
		}

		if (dodgeAmount == 20) {
			gameStart = false;
			cubeExist = false;
			if (!panelShow){
				float panelZ = -6.5f - 0.15f + (getSize.z/2f);
				Vector3 panelPos = new Vector3(0f, 1.7f, panelZ);
				Instantiate(panelPrefab, panelPos, Quaternion.identity);
				panelShow = true;
			}
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

	private void startTime(){
		if (countdown > 0f){
			countdown -= Time.deltaTime;
			gameStateText.text = "Starting in " + Mathf.Round(countdown) + "...";
		} else if (0 == Mathf.Round(countdown) && !gameStart) {
			gameStart = true;
			gameStateText.text = "Dodge the walls!";
		}
	}
}
