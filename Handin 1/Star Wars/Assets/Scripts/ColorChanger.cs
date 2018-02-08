using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
	GameObject path;
	GameObject shuttle;
	Renderer renderer;

	void Start () 
	{
		shuttle = GameObject.Find("IT_space_shuttle");
		path = GameObject.Find("IT_landing");
		renderer = GetComponent<Renderer> ();
	}

	void Update () 
	{
		float dot_forward_right = Vector3.Dot (path.transform.forward, shuttle.transform.right);
		float dot_forward_up = Vector3.Dot (path.transform.forward, shuttle.transform.up);

		// Smooth transition form green to red 
		float r1, g1, r2, g2, b = 0.0f;
		r1 = Mathf.Abs (dot_forward_right) ;
		g1 = (1 - r1) / 2;
		r2 = Mathf.Abs (dot_forward_up) ;
		g2 = (1 - r2) / 2;

		Color c = new Color (r1+r2, g1 + g2, b);
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
