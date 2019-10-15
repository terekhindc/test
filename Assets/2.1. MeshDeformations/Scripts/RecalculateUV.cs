using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecalculateUV : MonoBehaviour
{

    [SerializeField] Vector2 [] UV;

    Mesh mesh;
    Vector3[] vertecies;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        UV = new Vector2 [mesh.vertices.Length];
        vertecies = mesh.vertices;
        		
		for (int i = 0, y = 0; y <= transform.localScale.y; y++) {
			for (int x = 0; x <= transform.localScale.z; x++, i++) {				
				UV[i] = new Vector2(x / transform.localScale.z, y / transform.localScale.y);
			}
		}
		
		mesh.uv = UV;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
