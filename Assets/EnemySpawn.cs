using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float delayTime;

    // Start is called before the first frame update
    void Start()
    {

        transform.DOLocalMoveZ(transform.position.z-50.0f, moveTime).SetDelay(delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
