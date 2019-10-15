using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVertex : MonoBehaviour
{

    Mesh mesh;
    [SerializeField]Vector3 [] vertices;
    [SerializeField]float radius = 0.01f;    

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;       
    }

    private void Update()
    {        
        mesh.vertices = vertices;        
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + vertices[i], radius);            
        }
    }
}
