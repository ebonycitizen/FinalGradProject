using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform forwardPos;
    private Vector3 oldForwardPos;

    // Start is called before the first frame update
    void Start()
    {
        oldForwardPos = forwardPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(forwardPos.position-oldForwardPos);
        oldForwardPos = forwardPos.position;
    }
}
