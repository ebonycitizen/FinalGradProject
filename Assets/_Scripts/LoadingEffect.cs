using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingEffect : MonoBehaviour
{
    [SerializeField]
    private float enlargeFactor = 6f;
    [SerializeField]
    private float shrinkFactor = 10f;
    [SerializeField]
    private float duration = 4f;
    [SerializeField]
    private float initSpeed = 10f;

    private void OnEnable()
    {
        StartCoroutine("PlayEffect");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator PlayEffect()
    {
        transform.localScale = Vector3.zero;
        float curTime = 0f;

        //enlarge
        while(curTime <= duration)
        {
            transform.localScale += Vector3.one * initSpeed * Time.deltaTime;
            initSpeed += enlargeFactor * Time.deltaTime;
            curTime += Time.deltaTime;
            yield return null;
        }
        //load new stage

        yield return new WaitForSeconds(0.2f);

        //shrink
        while (true)
        {
            if(transform.localScale.x <= 0)
            {
                transform.localScale = Vector3.zero;
                yield break;
            }
            transform.localScale -= Vector3.one * initSpeed * Time.deltaTime;
            initSpeed += shrinkFactor * Time.deltaTime;
            curTime += Time.deltaTime;
            yield return null;
        }

        //unload this scene
    }
}
