using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class VertexForm : MonoBehaviour
{

    Mesh mesh;

    [SerializeField] float radius = 0.5f;
    Vector3 [] vertex;    
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int deep;

    void Start()
    {
        StartCoroutine(Create());
    }

    private void Update()
    {
        
    }

    IEnumerator Create ()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        vertex = new Vector3[width * height * deep];        
        mesh.name = "ProcedureMesh";

        int v=0;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < deep; z++)
            {
                vertex[v++] = new Vector3(x, 0, z);
                yield return new WaitForSeconds(0.05f);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                vertex[v++] = new Vector3(x, y, 0);
                yield return new WaitForSeconds(0.05f);
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int z = 0; z < deep; z++)
            {
                vertex[v++] = new Vector3(0, y, z);
                yield return new WaitForSeconds(0.05f);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < deep; z++)
            {
                vertex[v++] = new Vector3(x, height, z);
                yield return new WaitForSeconds(0.05f);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < deep; z++)
            {
                vertex[v++] = new Vector3(x, height, z);
                yield return new WaitForSeconds(0.05f);
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int z = 0; z < deep; z++)
            {
                vertex[v++] = new Vector3(width, y, z);
                yield return new WaitForSeconds(0.05f);
            }
        }        

        yield return null;
    }

    private void OnDrawGizmos()
    {
        if (mesh == null)
        {
            return;
        }

        Gizmos.color = Color.black;

        for (int i = 0; i < vertex.Length; i++)
        {
            Gizmos.DrawSphere(vertex[i], radius);
        }
    }
}
