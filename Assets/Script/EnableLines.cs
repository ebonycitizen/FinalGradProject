using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLines : MonoBehaviour
{
    [SerializeField]
    private float minIntervalSec;
    [SerializeField]
    private float maxInrervalSec;

    private ParticleSystem[] lines;
    private float duration;

    private void Awake()
    {
        lines = new ParticleSystem[transform.childCount];

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = transform.GetChild(i).GetComponent<ParticleSystem>();
        }

        duration = lines[0].main.duration;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Play");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Play()
    {
        while(true)
        {
            float rand = Random.Range(minIntervalSec, maxInrervalSec);
            yield return new WaitForSeconds(rand);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].Play();
            }
            yield return new WaitForSeconds(duration);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].Stop();
            }
        }
    }
}
