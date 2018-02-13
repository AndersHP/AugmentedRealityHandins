
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter3 : MonoBehaviour {

	GameObject falcon;
	GameObject tieFighter;

	public ParticleSystem explosion;

	public float rayLength; 
	private Ray ray; 
	private Ray ray2;
	private Material material;


	Vector3 topCannonPos = new Vector3(0, 2.5f, 0);
	public Quaternion rotation = Quaternion.Euler(0, 0, 0);
//	Vector3 rightCannonPos = new Vector3(0.4f, 0, 7f);


	// Use this for initialization
	void Start () {
		falcon = GameObject.Find ("IT_Falcon");
		tieFighter = GameObject.Find ("IT_TIE_Fighter");
		//		ParticleSystem exp = GetComponents<ParticleSystem> ("Explosion");
		ray = new Ray ();
//		ray2 = new Ray ();

	}

	// Update is called once per frame
	void Update () {


		Vector3 worldPosTop =   falcon.transform.position + topCannonPos + falcon.transform.rotation * topCannonPos;
//		Vector3 worldPosRight =  falcon.transform.position + rightCannonPos + falcon.transform.rotation * rightCannonPos;


		if (Input.GetKeyDown ("space")) {
			Debug.Log("space key was pressed");
			//			ray = new Ray (falcon.transform.position, falcon.transform.forward);
			ray.origin = worldPosTop;
//			ray2.origin = worldPosRight;

			ray.direction = rotation * falcon.transform.forward;
//			ray2.direction = falcon.transform.forward;
		}

		if (Physics.Raycast(ray.origin, ray.direction, rayLength)){
			Debug.Log ("Hit an enemy");
			//			Instantiate (tieFighter, hit.point, Quaternion.identity);
//			Explode();
		}

		if (Input.GetKeyUp ("space")) {
			Debug.Log("space key was released");
			ray.origin = new Vector3 (0, 0, 0);
			ray.direction = new Vector3 (0, 0, 0);

//			ray2.origin = new Vector3 (0, 0, 0);
//			ray2.direction = new Vector3 (0, 0, 0);
		}



	}


	private void OnGUI()
	{
		GUI.color = Color.red;
		GUI.Label (new Rect (10, 10, 500, 100), "LocalPosition falcon: " + falcon.transform.localPosition);
		GUI.Label (new Rect (10, 30, 500, 100), "LocalPosition tie fighter: " + tieFighter.transform.localPosition);


		// forward dotted with right = 0 if two forward vectors are aligned
		//		GUI.Label (new Rect (10, 50, 500, 100), "DotProduct forward: " + Vector3.Dot(path.transform.forward, shuttle.transform.right));

	}

	public void OnRenderObject() {

		if (material == null) {
			material = new Material (Shader.Find ("Hidden/Internal-Colored")); 
		}
		material.SetPass (0);

		GL.Begin(GL.LINES); 
		GL.Color(Color.yellow); 
		GL.Vertex(ray.origin); 
		GL.Vertex(ray.origin + ray.direction * rayLength); 
//		GL.Color(Color.green); 
//		GL.Vertex(ray2.origin); 
//		GL.Vertex(ray2.origin + ray2.direction * rayLength); 
		GL.End();
	}

	void Explode() {
		//		ParticleSystem explosion = tieFighter.GetComponent<ParticleSystem>();
		explosion.Play();
	}
}
