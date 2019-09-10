using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotio = 0.02f;

    [SerializeField]
    private float rotationDrag;

    [SerializeField]
    private Transform playerTransform;

    private Quaternion rotate;
    private Vector3 oldPos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //transform.position = playerTransform.position;
    }

    private void FixedUpdate()
    {
        transform.rotation = rotate;

        if ((transform.position - oldPos).magnitude < rotationDrag)
            return;
        var diff = transform.position - oldPos;
        var targetRot = Quaternion.LookRotation(diff);

        oldPos = transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotio);

        rotate = transform.rotation;
    }
}
