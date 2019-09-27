using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HI5;

public class LockOnTarget : MonoBehaviour
{
    [SerializeField]
    private Grab rightHand;
    [SerializeField]
    private Grab leftHand;

    [SerializeField]
    private GameObject rightCursor;
    [SerializeField]
    private GameObject leftCursor;

    [SerializeField]
    private int lockNumMax = 8;//ロックオンできる最大数
    [SerializeField]
    private int targetLayer;

    [SerializeField]
    private float atkSpeedRequire;

    [SerializeField]
    private GameObject lockOnCursorPrefab;

    private List<GameObject> lockOnTargets;

    private void Awake()
    {
        lockOnTargets = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowCursor();
        LockOn();
        Attack();
    }

    private void ShowCursor()
    {
        rightCursor.transform.position = rightHand.GetPalmCenterPos() + rightHand.GetForward() * rightHand.GetRayLength();
        leftCursor.transform.position = leftHand.GetPalmCenterPos() + leftHand.GetForward() * leftHand.GetRayLength();
    }

    private void LockTarget(GameObject target)
    {
        if (target != null && !lockOnTargets.Contains(target))
        {
            lockOnTargets.Add(target);
            Instantiate(lockOnCursorPrefab, target.transform);
        }
    }

    private void LockOn()
    {
        if (lockOnTargets.Count >= lockNumMax)
            return;

        GameObject rightTarget = rightHand.LockOn(targetLayer);
        GameObject leftTarget = leftHand.LockOn(targetLayer);

        LockTarget(rightTarget);
        LockTarget(leftTarget);
    }

    private void Attack()
    {
        if (lockOnTargets.Count <= 0)
            return;

        if (rightHand.GetVelocity().magnitude >= atkSpeedRequire || 
            leftHand.GetVelocity().magnitude >= atkSpeedRequire)
        {
            HI5_Manager.EnableBothGlovesVibration(400, 400);

            foreach (GameObject obj in lockOnTargets)
                DestroyObject(obj);

            lockOnTargets.Clear();
        }      
    }
}
