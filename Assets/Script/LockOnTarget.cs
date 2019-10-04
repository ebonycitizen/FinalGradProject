﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HI5;
using Valve.VR;

public class LockOnTarget : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction;

    [SerializeField]
    private bool useCamera;
    [SerializeField]
    private bool useHand;

    [SerializeField]
    private RayFromCamera rayCamera;
    [SerializeField]
    private Grab rightHand;
    [SerializeField]
    private Grab leftHand;

    [SerializeField]
    private GameObject cameraCursor;
    [SerializeField]
    private GameObject rightCursor;
    [SerializeField]
    private GameObject leftCursor;

    [SerializeField]
    private int lockNumMax = 8;//ロックオンできる最大数
    [SerializeField]
    private string targetLayer;

    [SerializeField]
    private float atkSpeedRequire;

    [SerializeField]
    private GameObject lockOnCursorPrefab;

    private List<GameObject> lockOnTargets;

    private void Awake()
    {
        lockOnTargets = new List<GameObject>();

        cameraCursor.SetActive(false);
        rightCursor.SetActive(false);
        leftCursor.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(useCamera)
            cameraCursor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (useHand)
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
        GameObject cameraTarget = rayCamera.LockOn(targetLayer);

        if (useHand)
        {
            LockTarget(rightTarget);
            LockTarget(leftTarget);
        }
        if(useCamera)
        {
            LockTarget(cameraTarget);
        }
    }

    private void Attack()
    {
        if (lockOnTargets.Count <= 0)
            return;

        if (rightHand.GetVelocity().magnitude >= atkSpeedRequire || 
            leftHand.GetVelocity().magnitude >= atkSpeedRequire || GrabAction.stateDown)
        {
            //HI5_Manager.EnableBothGlovesVibration(400, 400);

            foreach (GameObject obj in lockOnTargets)
                Destroy(obj);

            lockOnTargets.Clear();
        }      
    }
}
