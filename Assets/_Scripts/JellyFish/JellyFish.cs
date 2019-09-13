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

    [SerializeField] private Material m_material = null;

    private Vector3 m_initPosition = Vector3.zero;

    private float m_randomRotationValue = 0;

    private float m_rotateStartTime = 0;

    private Color m_defaultColor;

    private bool m_shouldChangeColor = false;

    public void SetUp(float size, float rotationValue, float rotateStartTime, Vector3 initPosition, bool shouldChangeColor)
    {
        m_randomRotationValue = rotationValue;

        transform.localScale *= size;

        transform.position = initPosition;

        m_rotateStartTime = rotateStartTime;

        m_shouldChangeColor = shouldChangeColor;

        if (shouldChangeColor)
        {
            transform.GetComponentInChildren<Renderer>().material = m_material;
            m_defaultColor = m_material.color;
        }
    }
    
    public void OnStart()
    {
        if (m_shouldChangeColor)
        {
            var sequenceMove = DOTween.Sequence().AppendInterval(10).Append(m_material.DOColor(Color.red, 10))
                .Append(m_material.DOColor(m_defaultColor, 10));

            sequenceMove.Play();
        }

        Move();
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
