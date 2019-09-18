using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPathMove : MonoBehaviour
{
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float delayTime;
    [SerializeField]
    private Transform[] paths;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] movePath = new Vector3[paths.Length];

        for(int i=0;i<paths.Length;i++)
        {
            movePath[i] = paths[i].position;
        }

        transform.DOLocalPath(movePath, moveTime, PathType.CatmullRom)
           .SetEase(Ease.Linear).SetLookAt(0.05f, Vector3.forward).SetDelay(delayTime).OnComplete(() => Destroy(gameObject)); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
