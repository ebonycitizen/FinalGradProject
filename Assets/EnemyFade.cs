using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyFade : MonoBehaviour
{
    [SerializeField]
    private float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        DOTween.ToAlpha(() => mat.color, color => mat.color = color, 0, 1).From().SetDelay(delayTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
