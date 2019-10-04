using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThirdPersonAttack : MonoBehaviour
{
    [SerializeField]
    private Grab rightHand;
    [SerializeField]
    private Grab leftHand;

    [SerializeField]
    private Transform rotationRef;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotateSec;
    [SerializeField]
    private float moveDist;

    private ThirdPersonPlayerPosition thirdPerson;

    private bool isAttack;
    public bool GetIsAttack()
    {
        return isAttack;
    }

    private IEnumerator Rotate()
    {
        isAttack = true;
        Vector3 rotation = Vector3.zero;
        Vector3 position = target.localPosition;

        rotation = Vector3.forward * 360;

        Sequence s = DOTween.Sequence();
        s.Join(target.DOBlendableLocalRotateBy(rotation, rotateSec, RotateMode.FastBeyond360))
            .Join(target.DOLocalMove(Vector3.forward * moveDist, rotateSec))
            .AppendCallback(() => target.DOLocalMove(Vector3.zero, rotateSec).SetEase(Ease.OutQuad));

        s.Play();

        yield return new WaitForSeconds(rotateSec * 2f);
        isAttack = false;
    }

    public void Attack()
    {
        StartCoroutine("Rotate");
    }

    // Start is called before the first frame update
    void Start()
    {
        thirdPerson = Object.FindObjectOfType<ThirdPersonPlayerPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAttack && (rightHand.HasGrab() || leftHand.HasGrab() || Input.GetKeyDown(KeyCode.Space)))
        {
            Attack();
        }
    }
}
