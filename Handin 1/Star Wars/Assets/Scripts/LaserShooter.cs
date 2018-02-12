using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour {

	GameObject falcon;
	GameObject tieFighter;

	public float rayLength = 10; 
	private Ray ray; 
	private Material material;

	// Use this for initialization
	void Start () {
		falcon = GameObject.Find ("IT_Falcon");
		tieFighter = GameObject.Find ("IT_TIE_Fighter");
	}
	
	// Update is called once per frame
	void Update () {
		float falcon_forward = falcon.transform.forward;
		Debug.DrawRay(ray.origin, ray.direction * rayLength);
		
	}

	private void OnGUI()
	{
		GUI.color = Color.red;
		GUI.Label (new Rect (10, 10, 500, 100), "LocalPosition falcon: " + falcon.transform.localPosition);
		GUI.Label (new Rect (10, 30, 500, 100), "LocalPosition tie fighter: " + tieFighter.transform.localPosition);

		// forward dotted with right = 0 if two forward vectors are aligned
//		GUI.Label (new Rect (10, 50, 500, 100), "DotProduct forward: " + Vector3.Dot(path.transform.forward, shuttle.transform.right));

	}

	void OnRenderObject() {

		if (material == null) {
			material = new Material (Shader.Find ("Hidden/Internal-Colored")); 
		}
		material.SetPass (0);


		GL.Begin(GL.LINES); 
		GL.Color(Color.red); 
		GL.Vertex(ray.origin); 
		GL.Vertex(ray.origin + ray1.direction * rayLength); 
		GL.End();

	}
}
