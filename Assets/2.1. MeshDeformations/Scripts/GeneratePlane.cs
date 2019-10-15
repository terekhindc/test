using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GeneratePlane : MonoBehaviour
{

    [SerializeField] int xSize;
    [SerializeField] int ySize;

    [SerializeField] Vector3[] vertex;
    [SerializeField] int[] triangles;

    Mesh mesh;

    [SerializeField] float radius=0.02f;    


    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        mesh.name = "Procedure Mesh";

        Generate();
    }

    void Generate()
    {
        vertex = new Vector3[(xSize + 1) * (ySize + 1)];

        for (int vi=0, x=0; x<xSize; x++)
        {
            for (int y = 0; y < ySize; y++, vi++)
            {
                vertex[vi] = new Vector3(x, y);                
                mesh.vertices = vertex;
            }            
        }

        triangles = new int[6*xSize];

        int ti = 0; int ty = 3;

        triangles[ti] = triangles[ti + 3] = 0+ty;
        triangles[ti + 1] = 1+ty;
        triangles[ti + 2] = triangles[ti + 4] = xSize + 1;
        triangles[ti + 5] = triangles[ti+4] - 1;

        mesh.triangles = triangles;        
    }

    int[] NextTriangles(int i1, int i2, int i3) {

        int nexti1 = i1;
        int nexti2 = i2;
        int nexti3 = i2;

        return new int[3];
    }

    private void OnDrawGizmos()
    {
        if (vertex == null)
        {
            return;
        }

        Gizmos.color = Color.black;

        for (int i=0; i<vertex.Length; i++)
        {
            Gizmos.DrawSphere(vertex[i], radius);            
        }
    }
}
