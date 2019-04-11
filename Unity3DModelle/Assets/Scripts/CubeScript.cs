using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
	static Vector3 a = new Vector3(1,0,0);
	static Vector3 b = new Vector3(1,0,1);
	static Vector3 c = new Vector3(0,0,1);
	static Vector3 d = new Vector3(0,0,0);
	static Vector3 e = new Vector3(1,1,0);
	static Vector3 f = new Vector3(1,1,1);
	static Vector3 g = new Vector3(0,1,1);
	static Vector3 h = new Vector3(0,1,0);


    static Vector2 lo = new Vector2(0,1);
    static Vector2 ro = new Vector2(1, 1);
    static Vector2 lu = new Vector2(0, 0);
    static Vector2 ru = new Vector2(1, 0);

    


    [SerializeField]
    private Material mat;

	static Vector3[] vertices = {a,e,b,
								b,e,f,
								b,f,g,
								b,g,c,
								c,g,h,
								c,h,d,
								d,h,a,
								a,h,e,
								a,b,c,
								a,c,d,
								e,g,f,
								e,h,g};

    static Vector2[] uvs = { lu, lo, ru,
                            ru,lo,ro,
                            lu,lo,ro,
                            lu,ro,ru,
                            lu,lo,ro,
                            lu,ro,ru,
                            lu,lo,ru,
                            ru,lo,ro,
                            ro,ru,lu,
                            ro,lu,lo,
                            ru,lo,ro,
                            ru,lu,lo};

    static int[] indices = {0,1,2,
							3,4,5,
							6,7,8,
							9,10,11,
							12,13,14,
							15,16,17,
							18,19,20,
							21,22,23,
							24,25,26,
							27,28,29,
							30,31,32,
							33,34,35};
	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = indices;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
        
        mesh.uv = uvs;
        var mats = new Material[1];
        mats[0] = mat;
        rend.materials = mats;
		
	}
}
