using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
	GameObject path;
	GameObject shuttle;
	Renderer renderer;
	float epsilon = 0.05f;

	void Start () 
	{
		shuttle = GameObject.Find("IT_space_shuttle");
		path = GameObject.Find("IT_landing");
		renderer = GetComponent<Renderer> ();
	}

	void Update () 
	{
		// if some dotproduct (local or global pos???) is close to 0, be green, if not red

		float dot = Vector3.Dot (path.transform.forward, shuttle.transform.right);

		// Smooth transition form green to red 
		float r, g, b = 0.0f;
		r = Mathf.Abs (dot);
		g = 1 - r;
		Color c = new Color (r,g,b);
		renderer.material.color = c; 
	
	}

	private void OnGUI()
	{
		GUI.color = Color.red;
		GUI.Label (new Rect (10, 10, 500, 100), "LocalPosition path: " + path.transform.localPosition);
		GUI.Label (new Rect (10, 30, 500, 100), "LocalPosition shuttle: " + shuttle.transform.localPosition);

		// forward dotted with right = 0 if two forward vectors are aligned
		GUI.Label (new Rect (10, 50, 500, 100), "DotProduct forward: " + Vector3.Dot(path.transform.forward, shuttle.transform.right));

	}
}
