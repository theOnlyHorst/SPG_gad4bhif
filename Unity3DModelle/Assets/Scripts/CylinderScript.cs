using UnityEngine;
using System.Collections;

public class CylinderScript : MonoBehaviour
{
	static Vector3[] vertices;
	static int[] indices;
	static int n = 30;
	static CylinderScript()
	{
		vertices = new Vector3[n*2+2*n+2];
		for (int i = 0; i < n; i++)  // Mantel
		{
			vertices[i] = new Vector3(Mathf.Sin(i*2*Mathf.PI/n),1,Mathf.Cos(i*2*Mathf.PI/n));
			vertices[n+i] = new Vector3(Mathf.Sin(i*2*Mathf.PI/n),-1,Mathf.Cos(i*2*Mathf.PI/n));
		}
		for (int i = 0; i < n; i++)  // Grund- und Deckfläche
		{
			vertices[2*n+i] = new Vector3(Mathf.Sin(i*2*Mathf.PI/n),1,Mathf.Cos(i*2*Mathf.PI/n));
			vertices[3*n+i] = new Vector3(Mathf.Sin(i*2*Mathf.PI/n),-1,Mathf.Cos(i*2*Mathf.PI/n));
		}
		vertices[4*n] = new Vector3(0,1,0);
		vertices[4*n+1] = new Vector3(0,-1,0);
		indices = new int[n*2*3+n*3*2];
		int j = 0;
		for (int i = 0; i < n; i++) // Mantel
		{
			indices[j++] = i;
			indices[j++] = n+i%n;
			indices[j++] = (i+1)%n;
			indices[j++] = (i+1)%n;
			indices[j++] = n+i%n;
			indices[j++] = n+(i+1)%n;
		}
		for (int i = 0; i < n; i++) // Deckfläche
		{
			indices[j++] = 4*n;
			indices[j++] = 2*n+i%n;
			indices[j++] = 2*n+(i+1)%n;
		}
		for (int i = 0; i < n; i++) // Deckfläche
		{
			indices[j++] = 4*n+1;
			indices[j++] = 3*n+(i+1)%n;
			indices[j++] = 3*n+i%n;
		}

	}

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = indices;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		//mesh.Optimize();
	}
}
