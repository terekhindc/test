﻿using UnityEngine;
using System.Collections;

// this example creates a quad mesh from scratch, creates bones
// and assigns them, and animates the bones motion to make the
// quad animate based on a simple animation curve.
public class BindPoseExample : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);

        // assign the array of colors to the Mesh.
        mesh.colors = colors;
    }
}