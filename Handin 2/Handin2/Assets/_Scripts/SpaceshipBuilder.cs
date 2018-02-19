using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Builds a sic spaceship
// To use, attach to empty gameobject  (right click -> create empty). Also add "Mesh Filter" and a "Mesh renderer" to this game object. Finally add material and choose a shader for the material.
public class SpaceshipBuilder : MonoBehaviour {

	private Mesh mesh;
	void Start () 
	{
		mesh = new Mesh ();
		GetComponent<MeshFilter>().mesh = mesh;

		mesh.vertices = vertices();
		mesh.triangles = triangles();
		mesh.RecalculateNormals();

		// If using "particles/additive(soft)" shader it looks cool with random vertex colors

		mesh.colors = newVertexColors();
	}		

	
	void Update(){
		//mesh.Clear();
		// Flap dem wings 
        Vector3[] v = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int[] wingVertices = {2,43,44,45,6,40,41,42};
        foreach(int i in wingVertices) {
            v[i] += Vector3.up * ((2*Time.time % 2) -1) /10   ;
		}

        mesh.vertices = v;
		mesh.colors = newVertexColors();
	}

	Color[] newVertexColors()
	{
		Color[] colors = new Color[54];		
		for(int i = 0; i<mesh.vertices.Length; i++)
			colors[i] = Random.ColorHSV();
		return colors;
	}
	

	// Returns array of vertices. 
	// All vertices except 2 have y = 0
	Vector3[] vertices()
	{
		Vector3[] vertices = new Vector3[54];

		// y = 0
		vertices[0] = new Vector3(0, 0, 1);
		vertices[1] = new Vector3(-1, 0, 0);
		vertices[2] = new Vector3(-4, 0, 1);
		vertices[3] = new Vector3(-1.5F, 0, 2.5F);
		vertices[4] = new Vector3(0, 0, 7);
		vertices[5] = new Vector3(1.5F, 0, 2.5F);
		vertices[6] = new Vector3(4, 0, 1);
		vertices[7] = new Vector3(1, 0, 0);
		vertices[8] = new Vector3 (0, 0, 2.5F);
		// y = 1.5
		vertices [9] = new Vector3 (-1, 1.5F, 1);
		vertices [10] = new Vector3 (1, 1.5F, 1);
		
		//
		//	Duplicates of the 11 vertices, so that no vertice is in > 1 triangles. 
		//  This is needed for the normal vectors to produce sharp edges. (see hint in handin desc.)
		//
	
		// vertices[4] duplicates
		vertices[11] = new Vector3(0, 0, 7);
	 	vertices[12] = new Vector3(0, 0, 7);
		vertices[13] = new Vector3(0, 0, 7);
		vertices[14] = new Vector3(0, 0, 7);
		vertices[15] = new Vector3(0, 0, 7);
		// vertices[9] duplicates
		vertices [16] = new Vector3 (-1, 1.5F, 1);
		vertices [17] = new Vector3 (-1, 1.5F, 1);
		vertices [18] = new Vector3 (-1, 1.5F, 1);
		vertices [19] = new Vector3 (-1, 1.5F, 1);
		vertices [20] = new Vector3 (-1, 1.5F, 1);
		vertices [21] = new Vector3 (-1, 1.5F, 1);
		// vertices[1] duplicates
		vertices[22] = new Vector3(-1, 0, 0);
		vertices[23] = new Vector3(-1, 0, 0);
		// vertices[0] duplicates
		vertices[24] = new Vector3(0, 0, 1);
		vertices[25] = new Vector3(0, 0, 1);	
		vertices[26] = new Vector3(0, 0, 1);
		vertices[27] = new Vector3(0, 0, 1);
		vertices[28] = new Vector3(0, 0, 1);	
		vertices[29] = new Vector3(0, 0, 1);
		vertices[30] = new Vector3(0, 0, 1);
		vertices[31] = new Vector3(0, 0, 1);	
		// vertices[8] duplicates
		vertices[32] = new Vector3 (0, 0, 2.5F);
		vertices[33] = new Vector3 (0, 0, 2.5F);
		// vertices[3] duplicates
		vertices[34] = new Vector3(-1.5F, 0, 2.5F);
		vertices[35] = new Vector3(-1.5F, 0, 2.5F);
		vertices[36] = new Vector3(-1.5F, 0, 2.5F);
		// vertices[5] duplicates
		vertices[37] = new Vector3(1.5F, 0, 2.5F);
		vertices[38] = new Vector3(1.5F, 0, 2.5F);
		vertices[39] = new Vector3(1.5F, 0, 2.5F);
		// vertices[6] duplicates
		vertices[40] = new Vector3(4, 0, 1);
		vertices[41] = new Vector3(4, 0, 1);
		vertices[42] = new Vector3(4, 0, 1);
		// vertices[2] duplicates
		vertices[43] = new Vector3(-4, 0, 1);
		vertices[44] = new Vector3(-4, 0, 1);
		vertices[45] = new Vector3(-4, 0, 1);
		// vertices[7] duplicates
		vertices[46] = new Vector3(1, 0, 0);
		vertices[47] = new Vector3(1, 0, 0);
		// vertices[10] duplicates
		vertices [48] = new Vector3 (1, 1.5F, 1);
		vertices [49] = new Vector3 (1, 1.5F, 1);
		vertices [50] = new Vector3 (1, 1.5F, 1);
		vertices [51] = new Vector3 (1, 1.5F, 1);
		vertices [52] = new Vector3 (1, 1.5F, 1);
		vertices [53] = new Vector3 (1, 1.5F, 1);

		return vertices;
	}	
	
	// Returns array of indices corresponding to triangles. 
	// index 0,1,2 is interpreted as a triangle, so is 3,4,5 etc. 
	// in total 54/3 = 18 triangles
	int[] triangles()
	{
		int[] tri = new int[54];

		// Upper hull of ship

		tri[0] = 0;
		tri[1] = 1;
		tri[2] = 9;

		tri[3] = 16;
		tri[4] = 22;
		tri[5] = 2;

		tri[6] = 17;
		tri[7] = 43;
		tri[8] = 3;

		tri [9] = 18;
		tri [10] = 34;
		tri [11] = 4;

		tri [12] = 19;
		tri [13] = 11;
		tri [14] = 8;

		tri [15] = 32;
		tri [16] = 12;
		tri [17] = 10;

		tri [18] = 13;
		tri [19] = 5;
		tri [20] = 48;

		tri [21] = 37;
		tri [22] = 6;
		tri [23] = 49;

		tri [24] = 40;
		tri [25] = 7;
		tri [26] = 50;

		tri [27] = 46;
		tri [28] = 24;
		tri [29] = 51;

		tri [30] = 25;
		tri [31] = 20;
		tri [32] = 52;

		tri [33] = 21;
		tri [34] = 33;
		tri [35] = 53;

		// bottom of ship

		tri [36] = 26;
		tri [37] = 44;
		tri [38] = 23;

		tri [39] = 27;
		tri [40] = 35;
		tri [41] = 45;

		tri [42] = 28;
		tri [43] = 14;
		tri [44] = 36;

		tri [45] = 29;
		tri [46] = 38;
		tri [47] = 15;

		tri [48] = 30;
		tri [49] = 41;
		tri [50] = 39;

		tri [51] = 31;
		tri [52] = 47;
		tri [53] = 42;

		return tri;
	}
}
