using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerPosition : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance;

    ContactPoint[] c;
    private GameObject collideTarget;
    private Vector3 targetPos;
    private Vector3 test;

    private Vector3 targetPosOld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        targetPos = Quaternion.Euler(target.eulerAngles) * transform.forward * distance;

        //transform.localPosition = velocity;

        Vector3 moveDirection = (targetPos - targetPosOld).normalized;
        Debug.Log(moveDirection);

        if (collideTarget != null)
        {
            foreach (ContactPoint ca in c)
            {
                if (ca.normal.x != 0)
                {
                    if ((ca.normal.x == 1 && moveDirection.x < 0) || (ca.normal.x == -1 && moveDirection.x > 0))
                        targetPos.x = targetPosOld.x;
                }
                if (ca.normal.y != 0)
                {
                    if ((ca.normal.y == 1 && moveDirection.y < 0) || (ca.normal.y == -1 && moveDirection.y > 0))
                        targetPos.y = targetPosOld.y;
                }
                if (ca.normal.z != 0)
                {
                    if ((ca.normal.z == 1 && moveDirection.z < 0) || (ca.normal.z == -1 && moveDirection.z > 0))
                        targetPos.z = targetPosOld.z;
                }
            }
            //&& moveDirection.x <= 0)
            //velocity.x = velocityOld.x;
        }

        transform.localPosition = Vector3.Slerp(transform.localPosition, targetPos, Time.deltaTime * 2f);
        //transform.localPosition = velocity;
        Debug.Log(targetPosOld);
        targetPosOld = targetPos;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Stage"))
            return;

        collideTarget = collision.gameObject;
        c = collision.contacts;
    }

    private void OnCollisionExit(Collision collision)
    {
        collideTarget = null;
    }
}
