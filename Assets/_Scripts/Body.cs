using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    private Material lightUpMat;

    private Material normalMat;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMat = meshRenderer.material;
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
        if (meshRenderer.material != lightUpMat)
            meshRenderer.material = lightUpMat;

        yield return new WaitForSeconds(0.6f);

        meshRenderer.material = normalMat;
    }
    public void Appear()
    {
        StartCoroutine("AppearAnime");
    }

    //public void Disappear()
    //{
    //    if(meshRenderer.material != normalMat)
    //    meshRenderer.material = normalMat;
    //}
}
