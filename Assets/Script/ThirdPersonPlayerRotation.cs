using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform forwardPos;

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
        transform.rotation = Quaternion.LookRotation(forwardPos.forward);
    }
}
