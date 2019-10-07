using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustThridPersonDist : MonoBehaviour
{
    [SerializeField]
    private Transform originAxis;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private float rayDistance;

    private Vector3 normalDist;
    [SerializeField]
    private SkinnedMeshRenderer thirdPersonSize;
    private RaycastHit hit;
    bool isHit;

    private Vector3 rayDirection;

    // Start is called before the first frame update
    void Start()
    {
        normalDist = transform.localPosition;
        //Debug.Log(normalDist);
    }

    // Update is called once per frame
    void Update()
    {

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
    //private void CheckCollision()
    //{
    //    rayDirection = (transform.position - originAxis.position).normalized;

    //    isHit = Physics.Raycast(originAxis.position, originAxis.forward, out hit, rayDistance, 1 << LayerMask.NameToLayer("Stage"));
    //    isHit = Physics.BoxCast(originAxis.position, thirdPersonSize.bounds.extents, rayDirection, out hit, Quaternion.identity, rayDistance, 1 << 17);
    //    if (isHit)
    //    {

    //        Debug.Log(hit.collider.contactOffset);
    //        Debug.Log(hit.collider.ClosestPoint(transform.position));
    //        Debug.Log(hit.normal.normalized);
    //        Debug.Log((hit.collider.ClosestPoint(transform.position) - hit.transform.position).normalized);
    //    }

    //}

    /*UPDATE*/

    //Collider[] c = Physics.OverlapBox(thirdPersonSize.bounds.center, thirdPersonSize.bounds.size, Quaternion.identity,1 << 17);
    //if(c.Length!=0)
    //Debug.Log(c[0].name);


    //if (c.Length != 0 && hit.collider == c[0])
    //    transform.localPosition = Vector3.Slerp(transform.localPosition, originAxis.transform.InverseTransformPoint(originAxis.position + originAxis.forward * hit.distance), lerpSpeed * Time.deltaTime);

    //if(!isHit || c.Length == 0)
    //    transform.localPosition = Vector3.Slerp(transform.localPosition, normalDist, lerpSpeed * Time.deltaTime);

    ////transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
    //CheckCollision();


    //if (isHit)
    //{
    //    transform.position = Vector3.Slerp(transform.position, originAxis.position + rayDirection * hit.distance, lerpSpeed * Time.deltaTime);
    //}
    //else
    //{
    //    transform.localPosition = Vector3.Slerp(transform.localPosition, normalDist, lerpSpeed * Time.deltaTime);
    //}
    #endregion
}
