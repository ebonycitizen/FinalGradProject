using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx.Triggers;

public class JellyFish : MonoBehaviour
{
    [SerializeField] private float floatingTime = 10;

    [SerializeField] private float increasePositionY = 100;

    [SerializeField] private string cleanTag = "Clean";

    private Vector3 m_initPosition = Vector3.zero;

    private float m_randomRotationValue = 0;

    private float m_rotateStartTime = 0;

    public void SetUp(float size,float rotationValue ,float rotateStartTime,Vector3 initPosition)
    {
        m_randomRotationValue = rotationValue;

        transform.localScale *= size;

        transform.position = initPosition;

        m_rotateStartTime = rotateStartTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_initPosition = transform.position;

        Move();

        ObservableUpdate();

    }
    private void ObservableUpdate()
    {
        this.OnTriggerEnterAsObservable()
            .Where(x => x.gameObject.tag == cleanTag)
            .Subscribe(_ => Destroy(this.gameObject))
            .AddTo(this.gameObject);
    }

    private void Move()
    {
        m_initPosition = transform.position;

        var sequenceMove = DOTween.Sequence()
            .Append(transform.DOLocalMove(m_initPosition + new Vector3(0, increasePositionY, 0), floatingTime));
        
        sequenceMove.Play();

        Sequence move = DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 0, m_randomRotationValue), 3, RotateMode.LocalAxisAdd))
            .Append(transform.DORotate(new Vector3(0, 0, -m_randomRotationValue), 3, RotateMode.LocalAxisAdd))
            .Append(transform.DORotate(new Vector3(0, 0, -m_randomRotationValue), 3, RotateMode.LocalAxisAdd))
            .Append(transform.DORotate(new Vector3(0, 0, m_randomRotationValue), 3, RotateMode.LocalAxisAdd))
            .AppendInterval(m_rotateStartTime);

        move.Play().SetLoops(-1);

    }
}
