using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChanger : MonoBehaviour {

	GameObject spaceShuttle;
	GameObject earth;

	// Use this for initialization
	void Start () {
		spaceShuttle = GameObject.Find("IT_Space_Shuttle");
		earth = GameObject.Find("IT_Earth");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnGUI()
	{
		GUI.color = Color.red;
		GUI.Label (new Rect (10, 10, 500, 100), "LocalPosition space shuttle: " + spaceShuttle.transform.localPosition);
		GUI.Label (new Rect (10, 30, 500, 100), "LocalPosition earth: " + earth.transform.localPosition);

		// forward dotted with right = 0 if two forward vectors are aligned
//		GUI.Label (new Rect (10, 50, 500, 100), "DotProduct forward: " + Vector3.Dot(path.transform.forward, shuttle.transform.right));

	}
}
