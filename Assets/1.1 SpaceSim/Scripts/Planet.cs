using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform clouds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1*Time.deltaTime, 0);
        clouds.Rotate(0, 0.5f * Time.deltaTime,0);
    }
}
