using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAnalityc : MonoBehaviour
{

    Mesh mesh;
    [SerializeField] float radius = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        for (int i=0; i<mesh.vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + mesh.vertices[i], radius);
        }
        
    }
}
