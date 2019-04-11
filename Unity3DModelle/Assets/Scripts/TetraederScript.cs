using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraederScript : MonoBehaviour
{
    static Vector3 a = new Vector3(1,0,0);
    static Vector3 b = new Vector3(0,0,0);
    static Vector3 c = new Vector3(0.5f,0,1);
    static Vector3 d = new Vector3(0.5f,0.5f,0.5f);

    static Vector3[] vertices = { b, a, c,
                                  b,d,a,
                                  a,d,c,
                                  c,d,b};
    static int[] indices = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
