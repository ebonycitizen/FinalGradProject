using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    private Vector3 scale;
    private void Awake()
    {
        scale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AppearAnime()
    {
        Vector3 s = Vector3.zero;

        transform.localScale = s;
        while (transform.localScale.x < scale.x)
        {
            s.x += Time.deltaTime;
            s.y += Time.deltaTime;
            s.z += Time.deltaTime;

            transform.localScale = s;
            yield return null;
        }
    }

    private IEnumerator DisappearAnime()
    {
        Vector3 s = scale;

        transform.localScale = s;
        while (transform.localScale.x > 0)
        {
            s.x -= Time.deltaTime;
            s.y -= Time.deltaTime;
            s.z -= Time.deltaTime;

            transform.localScale = s;
            yield return null;
        }
    }

    public void Appear()
    {
        StartCoroutine("AppearAnime");
    }

    public void Disappear()
    {
        transform.localScale = Vector3.zero;
        //StartCoroutine("DisappearAnime");
    }
}
