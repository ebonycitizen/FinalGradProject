using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerPosition : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance;

    private ContactPoint[] c;

    private GameObject collideTarget;
    private Vector3 targetPos;
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


        transform.localPosition = Vector3.Slerp(transform.localPosition, targetPos, Time.deltaTime * 2f);
        //targetPosOld = targetPos;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Stage"))
            return;

        ContactPoint[] c = collision.contacts;

        //Debug.Log(c[0].normal + " " + c[0].separation);
        transform.position = transform.position + c[0].normal * -c[0].separation;
    }

    #region gomi

    //Vector3 moveDirection = (targetPos - targetPosOld).normalized;

    //if (collideTarget != null)
    //{
    //    foreach (ContactPoint ca in c)
    //    {
    //        if (ca.normal.x != 0)
    //        {
    //            if ((ca.normal.x > 0 && moveDirection.x < 0) || (ca.normal.x < 0 && moveDirection.x > 0))
    //                targetPos.x = targetPosOld.x;
    //        }
    //        if (ca.normal.y != 0)
    //        {
    //            if ((ca.normal.y > 0 && moveDirection.y < 0) || (ca.normal.y < 0 && moveDirection.y > 0))
    //                targetPos.y = targetPosOld.y;
    //        }
    //        if (ca.normal.z != 0)
    //        {
    //            if ((ca.normal.z > 0 && moveDirection.z < 0) || (ca.normal.z < 0 && moveDirection.z > 0))
    //                targetPos.z = targetPosOld.z;
    //        }
    //    }
    //}
    #endregion
}
