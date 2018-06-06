using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceState : MonoBehaviour {

	private Vector3 getSize;
	[SerializeField]
	private Transform platform;

	// Use this for initialization
	void Start () {
		getSize = OVRManager.boundary.GetDimensions(OVRBoundary.BoundaryType.PlayArea);
		platform.localScale = new Vector3(getSize.z, 3f, getSize.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
