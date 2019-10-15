using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GeneratePrism : MonoBehaviour
{

    [SerializeField] int xSize;
    [SerializeField] int zSize;

    [SerializeField] Color32[] color;

    [SerializeField] Vector3[] vertex;
    [SerializeField] int[] triangles;

    Mesh mesh;
    Vector2[] uvs;

    [SerializeField] float radius;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        mesh.name = "Procedure Mesh";

        StartCoroutine(Generate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        vertex = new Vector3[5];
        vertex[0] = new Vector3(0, 0, 0);
        vertex[1] = new Vector3(xSize, -xSize, xSize); // вправо вперёд
        vertex[2] = new Vector3(-xSize, -xSize, xSize); // влево вперёд
        vertex[3] = new Vector3(xSize, -xSize, -xSize); // вправо назад
        vertex[4] = new Vector3(-xSize, -xSize, -xSize); // влево назад

        triangles = new int[4*3];

        triangles[0] = 0;
        triangles[2] = 1;
        triangles[1] = 2;

        triangles[3] = 0;
        triangles[4] = 1;
        triangles[5] = 3;

        triangles[6] = 4;
        triangles[7] = 2;
        triangles[8] = 0;

        triangles[9] = 0;
        triangles[10] = 3;
        triangles[11] = 4;

        mesh.vertices = vertex;
        mesh.triangles = triangles;

        color = mesh.colors32 = new Color32[mesh.vertices.Length];

        for (int i = 0; i< color.Length; i++)
        {
            byte r = (byte)mesh.vertices[i].x;
            byte g = (byte)mesh.vertices[i].y;
            byte b = (byte)mesh.vertices[i].z;

            color[i] = new Color32(r, g, b, 255);            
        }

        mesh.colors32 = color;

        mesh.RecalculateNormals();
        
        uvs = new Vector2[vertex.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertex[i].z, vertex[i].x);
        }

        mesh.uv = uvs;


        while (Application.isPlaying)
        {

            for (int i = 0; i<vertex.Length; i++)
            {
                vertex[i] += new Vector3 (Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f)); 

                mesh.vertices = vertex;

                byte r = (byte)mesh.vertices[i].x;
                byte g = (byte)mesh.vertices[i].y;
                byte b = (byte)mesh.vertices[i].z;
                color[i] = new Color32(r, g, b, 255);
                mesh.colors32 = color;

                mesh.RecalculateNormals();
                yield return new WaitForSeconds(0.05f);
            }            
        }        
    }

    private void OnDrawGizmos()
    {
        if (vertex == null)
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
