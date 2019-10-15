using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiseUp : MonoBehaviour
{
    public Vector3 vector;
    Rigidbody rigid;
    float speed = 0;

    Button btn;

    // Start is called before the first frame update
    void Start()
    {        
        rigid = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 100;
        }
        else speed = 0;

        rigid.AddForce(vector*speed);
    }
}
