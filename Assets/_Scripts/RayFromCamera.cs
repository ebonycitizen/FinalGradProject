using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayFromCamera : MonoBehaviour
{
    private float rayLegth = 300;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject LockOn(string layer)
    {
        int layerMask = LayerMask.NameToLayer(layer);
        Debug.DrawRay(transform.position, transform.forward * rayLegth);
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, rayLegth , 1 << layerMask);

        if (isHit)
            return hit.transform.gameObject;

        return null;
    }
}
