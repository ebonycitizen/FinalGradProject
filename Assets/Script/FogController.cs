using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FogController : MonoBehaviour
{
    [SerializeField]
    private GameObject postProcessObj;

    private Vignette vignette;
    private float opacity;

    // Start is called before the first frame update
    void Start()
    {
        vignette = new Vignette();
        //vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        opacity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AddFog()
    {
        while (opacity <= 1)
        {
            vignette.opacity.Override(opacity);
            PostProcessManager.instance.QuickVolume(postProcessObj.layer, 1, vignette);

            opacity += Time.deltaTime * 2f;
            yield return null;
        }
        if(opacity >= 1)
            opacity = 1f;
    }

    private IEnumerator RemoveFog()
    {
        while (opacity >= 0)
        {
            vignette.opacity.Override(opacity);
            PostProcessManager.instance.QuickVolume(postProcessObj.layer, 1, vignette);

            opacity -= Time.deltaTime * 2f; ;
            yield return null;
        }
        if(opacity <= 0)
            opacity = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines();
            StartCoroutine("AddFog");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines();
            StartCoroutine("RemoveFog");
        }
    }
}
