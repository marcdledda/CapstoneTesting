using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeWallState : MonoBehaviour {

	private Vector3 getWidth;
	[SerializeField]
	private Transform platform;

	// Use this for initialization
	void Start () {
		getWidth = OVRManager.boundary.GetDimensions(OVRBoundary.BoundaryType.PlayArea);
		platform.localScale = new Vector3(getWidth.x, 1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
