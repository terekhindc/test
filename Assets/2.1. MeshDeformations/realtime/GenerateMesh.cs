using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GenerateMesh : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertex;
    int [] triangles;

    [SerializeField] Color32[] colors;

    [SerializeField]int xSize = 4;

    [SerializeField]float radius = 0.02f;

    Vector2 [] uvs;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh ();
        vertex = new Vector3[5];
        vertex[0] = new Vector3(0, 0, 0);
        vertex[1] = new Vector3(xSize, -xSize, xSize); // вправо вперёд
        vertex[2] = new Vector3(-xSize, -xSize, xSize); // влево вперёд
        vertex[3] = new Vector3(xSize, -xSize, -xSize); // вправо назад
        vertex[4] = new Vector3(-xSize, -xSize, -xSize); // влево назад

        triangles = new int[4 * 3];

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

        colors = new Color32 [vertex.Length];

        for (int i=0; i < colors.Length; i++)
        {

            byte colorX = (byte)vertex[i].x;
            byte colorY = (byte)vertex[i].y;
            byte colorZ = (byte)vertex[i].z;

            colors[i] = new Color32(colorX, colorY, colorZ, 255);
        }

        mesh.colors32 = colors;
        mesh.RecalculateNormals();

        uvs = new Vector2[vertex.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertex[i].x, vertex[i].z);
        }

        mesh.uv = uvs;

        StartCoroutine(ChangeVertex());
    }
  
    IEnumerator ChangeVertex ()
    {

        while (Application.isPlaying)
        {
            for (int i = 0; i < vertex.Length; i++)
            {
                vertex[i] += Vector3.up * Random.Range(-0.5f, 0.5f);
                mesh.vertices = vertex;
                yield return new WaitForSeconds(0.05f);
            }
        }
            
    }

}
