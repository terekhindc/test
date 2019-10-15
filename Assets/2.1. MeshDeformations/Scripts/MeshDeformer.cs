using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial_MeshDeformations
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MeshDeformer : MonoBehaviour
    {
        Mesh deformingMesh;
        Vector3[] originalVertices, displacedVertices;
        Vector3[] vertexVelocities;
        public float force = 10f;
        public float forceOffset = 0.1f;

        void Start()
        {
            deformingMesh = GetComponent<MeshFilter>().mesh;
            originalVertices = deformingMesh.vertices;
            displacedVertices = new Vector3[originalVertices.Length];

            for (int i = 0; i < originalVertices.Length; i++)
            {
                displacedVertices[i] = originalVertices[i];
            }

            vertexVelocities = new Vector3[originalVertices.Length];
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {                
                HandleInput();
            }

            for (int i = 0; i < displacedVertices.Length; i++)
            {
                UpdateVertex(i);
            }

            deformingMesh.vertices = displacedVertices;
            deformingMesh.RecalculateNormals();
        }

        void HandleInput()
        {            
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit))
            {
                MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
                if (deformer)
                {
                    Vector3 point = hit.point;
                    point += hit.normal * forceOffset;
                    deformer.AddDeformingForce(point, force);
                }
            }

        }        

        public void AddDeformingForce(Vector3 point, float force)
        {
            Debug.DrawLine(Camera.main.transform.position, point);
            for (int i = 0; i < displacedVertices.Length; i++)
            {
                AddForceToVertex(i, point, force);
            }
        }

        void AddForceToVertex(int i, Vector3 point, float force)
        {
            Vector3 pointToVertex = displacedVertices[i] - point;
            float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
            float velocity = attenuatedForce * Time.deltaTime;
            vertexVelocities[i] += pointToVertex.normalized * velocity;
        }

        void UpdateVertex(int i)
        {
            Vector3 velocity = vertexVelocities[i];
            displacedVertices[i] += velocity * Time.deltaTime;
        }
    }

}