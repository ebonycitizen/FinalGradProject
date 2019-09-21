using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFish : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float speedMin;
    [SerializeField]
    private float speedMax;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
