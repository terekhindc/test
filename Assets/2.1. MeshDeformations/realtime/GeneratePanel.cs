using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class GeneratePanel : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertex;
    int[] trianlges;

    [SerializeField] float radius = 0.02f;
    [SerializeField] int height = 2;
    [SerializeField] int width = 10;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        mesh.name = "Procedure Mesh";

        vertex = new Vector3[width * height];

        int i = 0;

        for (int x=0; x<width; x++)
        {
            for (int y=0; y<height; y++)
            {
                vertex[i] = new Vector3(x, y, 0);
                i++;
            }
        }

        mesh.vertices = vertex;
    }

    private void OnDrawGizmos()
    {
        if (mesh == null) return;

        Gizmos.color = Color.black;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + vertex[i], radius);
        }

    }
}
