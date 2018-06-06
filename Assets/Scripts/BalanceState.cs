using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceState : MonoBehaviour {

	private Vector3 getSize;
	[SerializeField]
	private Transform platform;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private GameObject blockPrefab;
	private float sizeZ = 0f;
	private int blockAmount;

	// Use this for initialization
	void Start () {
		getSize = OVRManager.boundary.GetDimensions(OVRBoundary.BoundaryType.PlayArea);
		getSize.z = sizeZ;
		platform.localScale = new Vector3(getSize.z + 0.15f, 3f, getSize.z + 0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		bool pressA = OVRInput.GetUp(OVRInput.Button.One);
		if (pressA){
			SpawnBlock();
			gameStateText.text = "Catch and Balance the Cubes!";
		}
	}

	public void SpawnBlock(){
		if (blockAmount > 10){
			float range = sizeZ * 0.5f - 0.06f;
			float position = Random.Range(-range, range);

			Vector3 objectPosition = new Vector3(position, 3f, range);

			Instantiate(blockPrefab, objectPosition, Quaternion.identity);
			blockAmount++;
		}
	}

}
