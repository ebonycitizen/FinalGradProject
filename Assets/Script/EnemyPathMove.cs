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
    private Transform pathRef;
    [SerializeField]
    private Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] movePath = new Vector3[pathRef.childCount-1];

        for(int i=0;i< movePath.Length;i++)
        {
            movePath[i] = pathRef.GetChild(i).localPosition;
        }

        transform.DOLocalPath(movePath, moveTime, PathType.CatmullRom)
           .SetEase(ease).SetLookAt(0.05f, Vector3.forward).SetDelay(delayTime)
           .OnComplete(() => DestroyObj()).GotoWaypoint(0,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObj()
    {
        //Destroy(gameObject);
    }
}
