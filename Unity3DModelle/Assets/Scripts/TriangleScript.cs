using UnityEngine;
using System.Collections;

public class TriangleScript : MonoBehaviour {
	static Vector3 a = new Vector3(1,0,0);
	static Vector3 b = new Vector3(0,0,0);
	static Vector3 c = new Vector3(0,0,1);

	static Vector3[] vertices = {a,b,c};
	static int[] indices = {0,1,2};
	
	void Start () {
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = indices;	
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		//mesh.Optimize();
	}
	
	
	void Update () {
	
	}
}
