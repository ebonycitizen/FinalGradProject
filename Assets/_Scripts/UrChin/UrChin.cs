using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


public class UrChin : MonoBehaviour
{
    [SerializeField] private float randomRange = 5;

    [SerializeField] private float durationToDestination = 3;

    [SerializeField] private GameObject centerRef;

    private bool isGoal = true;

    private Vector3 m_nextDestination = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        DoMove();
        Observable.Timer(System.TimeSpan.FromSeconds(1), System.TimeSpan.FromSeconds(1))
            .Where(_=> isGoal)
            .Subscribe(_ => DoMove())
            .AddTo(this.transform);

    }

    void DoMove()
    {
        Debug.Log("A");
        var randomDestination = centerRef.transform.position+ Random.insideUnitSphere* randomRange;

        m_nextDestination = randomDestination;

        var rb = GetComponent<Rigidbody>();

        rb.DOMove(m_nextDestination, durationToDestination).SetEase(Ease.Linear);
        transform.DOShakeRotation(3, 5, 3, 30).SetLoops(-1);
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, m_nextDestination));
        if (Vector3.Distance(transform.position, m_nextDestination) < 3)
        {
            isGoal = true;
        }
        else
        {
            isGoal = false;
        }
    }
}
