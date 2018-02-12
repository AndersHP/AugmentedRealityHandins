using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChanger : MonoBehaviour {

	GameObject spaceShuttle;
	GameObject earth;
	GameObject nose;

	void Start () 
	{
		spaceShuttle = GameObject.Find("IT_Space_Shuttle");
		earth = GameObject.Find("IT_Earth");
		nose = GameObject.Find ("IT_Space_Shuttle/nose");

		// TODO: Transform nose to world coords and then to earth coords. 
	}
	
	void Update () 
	{

		//Vector3 noseLocalPosition = nose.transform.localPosition;

	
	}

	private void OnGUI()
	{
		GUI.color = Color.red;

		Matrix4x4 shuttleToEarthTransform = earth.transform.worldToLocalMatrix * spaceShuttle.transform.localToWorldMatrix *  nose.transform.localToWorldMatrix;
		Vector3 pos = shuttleToEarthTransform.MultiplyPoint3x4(nose.transform.localPosition);

		GUI.Label (new Rect (10, 10, 500, 100), "LocalPosition earth: " + earth.transform.localPosition);
		GUI.Label (new Rect (10, 30, 500, 100), "NoseLocalPos (in earth): \n X: " + pos.x + " \n Y: " +  pos.y + "\n Z: " + pos.z);


		// TODO check its over the earth
		float distance = Mathf.Sqrt(Mathf.Pow(pos.x,2) + Mathf.Pow(pos.y,2));
		GUI.Label(new Rect (10, 190, 500, 100), "asd: " + distance);
			

		string hemisphere = pos.y > 0 ? "North" : "south";
		GUI.Label (new Rect (10, 90, 500, 100), "Hemisphere: " + hemisphere);
	}
}
