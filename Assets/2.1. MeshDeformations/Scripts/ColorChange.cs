using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        StartCoroutine(FadeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = renderer.material.color;
            c.r = f;
            renderer.material.color = c;
        }
    }

    IEnumerator FadeCoroutine()
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = renderer.material.color;
            c.r = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
