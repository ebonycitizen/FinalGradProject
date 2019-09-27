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
    private Transform target;
    [SerializeField]
    private float rotateSec;

    private ThirdPersonPlayerPosition thirdPerson;

    private bool isAttack;

    private IEnumerator Rotate(Vector3 from)
    {
        isAttack = true;
        Vector3 rotation = Vector3.zero;
        Vector3 position = target.localPosition;

        if (from.z > 180)
            rotation = Vector3.zero;
        else
             rotation = Vector3.forward * 360;

        Sequence s = DOTween.Sequence();
        s.Join(target.DORotate(rotation, rotateSec, RotateMode.FastBeyond360))
            .Join(target.DOLocalMove(position + target.forward * 5f, rotateSec))
            .AppendCallback(() => transform.localPosition = Vector3.Slerp(transform.localPosition, thirdPerson.GetTargetPos(), Time.deltaTime * 2f));

        s.Play();
        
        yield return new WaitForSeconds(rotateSec * 2f);
        isAttack = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        thirdPerson = Object.FindObjectOfType<ThirdPersonPlayerPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAttack && (rightHand.HasGrab() || leftHand.HasGrab()))
        {
            Vector3 from = target.eulerAngles;
            StartCoroutine("Rotate", from);

        }
    }
}
