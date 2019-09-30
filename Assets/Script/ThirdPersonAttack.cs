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
    [SerializeField]
    private float moveDist;

    private ThirdPersonPlayerPosition thirdPerson;

    private bool isAttack;
    public bool GetIsAttack()
    {
        return isAttack;
    }

    private IEnumerator Rotate(Vector3 from)
    {
        isAttack = true;
        Vector3 rotation = Vector3.zero;
        Vector3 position = target.localPosition;

        if (from.z > 180)
            rotation = Vector3.zero;
        else
             rotation = transform.forward.normalized * 360;
        Debug.Log(rotation);
        Sequence s = DOTween.Sequence();
        s.Join(target.DOLocalRotate(rotation, rotateSec, RotateMode.FastBeyond360))
            .Join(target.DOLocalMove(position + target.forward * moveDist, rotateSec))
            .AppendCallback(() => transform.localPosition = Vector3.Slerp(transform.localPosition, thirdPerson.GetTargetPos(), Time.deltaTime * 2f));

        s.Play();
        
        yield return new WaitForSeconds(rotateSec * 2f);
        isAttack = false;
    }

    public void Attack()
    {
        Vector3 from = target.eulerAngles;
        StartCoroutine("Rotate", from);
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
