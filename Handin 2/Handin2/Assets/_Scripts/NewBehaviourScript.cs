using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceshipBuilderBackup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = new Mesh ();
		GetComponent<MeshFilter>().mesh = mesh;
		float width = 2;
		float height = 2;
		Vector3[] vertices = new Vector3[11];

		// y = 0
		vertices[0] = new Vector3(0, 0, 1);
		vertices[1] = new Vector3(-1, 0, 0);
		vertices[2] = new Vector3(-2, 0, 1);
		vertices[3] = new Vector3(-1.5F, 0, 2.5F);
		vertices[4] = new Vector3(0, 0, 5);
		vertices[5] = new Vector3(1.5F, 0, 2.5F);
		vertices[6] = new Vector3(2, 0, 1);
		vertices[7] = new Vector3(1, 0, 0);
		vertices[8] = new Vector3 (0, 0, 2.5F);
	 	
		// y = 0.5

		vertices [9] = new Vector3 (-1, 0.5F, 1);
		vertices [10] = new Vector3 (1, 0.5F, 1);

		int[] tri = new int[54];

		// Upper hull of ship
		tri[0] = 0;
		tri[1] = 1;
		tri[2] = 9;

		tri[3] = 9;
		tri[4] = 1;
		tri[5] = 2;

		tri[6] = 9;
		tri[7] = 2;
		tri[8] = 3;

		tri [9] = 9;
		tri [10] = 3;
		tri [11] = 4;

		tri [12] = 9;
		tri [13] = 4;
		tri [14] = 8;

		tri [15] = 8;
		tri [16] = 4;
		tri [17] = 10;

		tri [18] = 4;
		tri [19] = 5;
		tri [20] = 10;

		tri [21] = 5;
		tri [22] = 6;
		tri [23] = 10;

		tri [24] = 6;
		tri [25] = 7;
		tri [26] = 10;

		tri [27] = 7;
		tri [28] = 0;
		tri [29] = 10;

		tri [30] = 0;
		tri [31] = 9;
		tri [32] = 10;

		tri [33] = 9;
		tri [34] = 8;
		tri [35] = 10;

		// bottom of shipp

		tri [36] = 0;
		tri [37] = 2;
		tri [38] = 1;

		tri [39] = 0;
		tri [40] = 3;
		tri [41] = 2;

		tri [42] = 0;
		tri [43] = 4;
		tri [44] = 3;

		tri [45] = 0;
		tri [46] = 5;
		tri [47] = 4;

		tri [48] = 0;
		tri [49] = 6;
		tri [50] = 5;

		tri [51] = 0;
		tri [52] = 7;
		tri [53] = 6;


//		Color[] colors = new Color[vertices.Length];
//		for (int i = 0; i < vertices.Length; i++)
//			colors[i] = new Color(0,1,0);
		

		mesh.vertices = vertices;
		mesh.triangles = tri;
		mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	}
		
}
